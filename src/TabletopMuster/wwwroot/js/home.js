// Main page: tabs <-> URL hash, filters and sorting, unit details popup, delete confirmation.
(() => {
    'use strict';

    // ---------- Tabs: #lists / #catalogue in the URL (so links and the Back button reopen the right tab) ----------
    // (The panes are #lists-pane / #catalogue-pane, so the hash doesn't make the browser scroll to them.)
    function showTabFromHash() {
        const id = location.hash.slice(1);
        const btn = id && document.querySelector(`[data-bs-toggle="tab"][data-bs-target="#${CSS.escape(id)}-pane"]`);
        if (btn) bootstrap.Tab.getOrCreateInstance(btn).show();
    }

    document.querySelectorAll('[data-bs-toggle="tab"]').forEach(btn => {
        btn.addEventListener('shown.bs.tab', () => {
            const id = btn.dataset.bsTarget.slice(1).replace(/-pane$/, '');
            history.replaceState(null, '', '#' + id);
        });
    });
    window.addEventListener('hashchange', showTabFromHash);
    showTabFromHash();

    // ---------- Filters and sorting (one scope per tab) ----------
    const comparators = {
        name: (a, b) => a.dataset.name.localeCompare(b.dataset.name),
        'points-asc': (a, b) => a.dataset.points - b.dataset.points,
        'points-desc': (a, b) => b.dataset.points - a.dataset.points,
        updated: (a, b) => b.dataset.updated.localeCompare(a.dataset.updated),
    };

    document.querySelectorAll('[data-filter-scope]').forEach(scope => {
        const state = { search: '', faction: '', source: '', category: '' };
        const items = [...scope.querySelectorAll('[data-item]')];
        const groups = [...scope.querySelectorAll('[data-group]')];
        const noResults = scope.querySelector('[data-no-results]');
        const sortSelect = scope.querySelector('[data-sort]');

        function apply() {
            let visible = 0;
            items.forEach(el => {
                const d = el.dataset;
                const show = (!state.search || d.name.includes(state.search))
                    && (!state.faction || d.faction === state.faction)
                    && (!state.source || d.source === state.source)
                    && (!state.category || d.category === state.category);
                el.classList.toggle('d-none', !show);
                if (show) visible++;
            });
            groups.forEach(g => {
                const n = g.querySelectorAll('[data-item]:not(.d-none)').length;
                g.classList.toggle('d-none', n === 0);
                const count = g.querySelector('[data-group-count]');
                if (count) count.textContent = n;
            });
            noResults?.classList.toggle('d-none', visible > 0);
        }

        function sort() {
            const compare = comparators[sortSelect?.value];
            if (!compare) return;
            scope.querySelectorAll('[data-sort-container]').forEach(container => {
                [...container.querySelectorAll(':scope > [data-item]')]
                    .sort(compare)
                    .forEach(el => container.appendChild(el));
            });
        }

        scope.querySelectorAll('[data-filter]').forEach(input => {
            input.addEventListener('input', () => {
                const key = input.dataset.filter;
                state[key] = key === 'search' ? input.value.trim().toLowerCase() : input.value;
                apply();
            });
        });

        scope.querySelectorAll('[data-category-chip]').forEach(chip => {
            chip.addEventListener('click', () => {
                scope.querySelectorAll('[data-category-chip]').forEach(c => {
                    c.classList.toggle('active', c === chip);
                    c.setAttribute('aria-pressed', String(c === chip));
                });
                state.category = chip.dataset.categoryChip;
                apply();
            });
        });

        sortSelect?.addEventListener('input', sort);
        sort();
        apply();
    });

    // ---------- Unit details popup ----------
    const dataEl = document.getElementById('catalogue-data');
    const unitModalEl = document.getElementById('unitModal');
    if (dataEl && unitModalEl) {
        const data = JSON.parse(dataEl.textContent);
        const units = new Map(data.units.map(u => [String(u.id), u]));
        const modal = bootstrap.Modal.getOrCreateInstance(unitModalEl);
        const slot = name => unitModalEl.querySelector(`[data-u-${name}]`);

        const initials = name => name.split(/\s+/).filter(Boolean).slice(0, 2).map(w => w[0].toUpperCase()).join('');

        document.addEventListener('click', e => {
            const btn = e.target.closest('[data-unit-open]');
            if (!btn) return;
            const u = units.get(btn.dataset.unitOpen);
            if (!u) return;

            slot('name').textContent = u.name;
            slot('meta').textContent = `${u.factionName} · ${u.category}`;
            slot('points').textContent = u.points;

            const art = slot('art');
            art.replaceChildren();
            if (u.imageUrl) {
                const img = document.createElement('img');
                img.src = u.imageUrl;
                img.alt = u.name;
                art.appendChild(img);
            } else {
                const span = document.createElement('span');
                span.className = 'unit-initials';
                span.setAttribute('aria-hidden', 'true');
                span.textContent = initials(u.name);
                art.appendChild(span);
            }

            const author = slot('author');
            author.classList.toggle('d-none', !u.isCustom);
            author.textContent = u.isCustom ? `Custom unit${u.authorName ? ' by ' + u.authorName : ''}` : '';

            const table = slot('stats');
            const head = table.querySelector('thead tr');
            const body = table.querySelector('tbody tr');
            head.replaceChildren();
            body.replaceChildren();
            data.stats.forEach(s => {
                const th = document.createElement('th');
                th.scope = 'col';
                th.title = s.name;
                th.textContent = s.key;
                head.appendChild(th);
                const td = document.createElement('td');
                td.textContent = u.stats[s.key] ?? '–';
                body.appendChild(td);
            });

            slot('rules').textContent = u.rules || 'No special rules.';
            modal.show(btn);
        });
    }

    // ---------- Delete confirmation ----------
    document.getElementById('deleteModal')?.addEventListener('show.bs.modal', e => {
        const btn = e.relatedTarget;
        if (!btn) return;
        e.target.querySelector('[data-delete-id]').value = btn.dataset.listId;
        e.target.querySelector('[data-delete-name]').textContent = btn.dataset.listName;
    });
})();
