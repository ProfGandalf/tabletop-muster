// Army list editor: add/remove units, live points total and limit warning.
// The list lives in `entries` (one unit id per squad) and is written into hidden
// Input.Entries[i].UnitId fields when the form is submitted.
(() => {
    'use strict';

    const form = document.getElementById('army-form');
    const dataEl = document.getElementById('editor-data');
    if (!form || !dataEl) return;

    const data = JSON.parse(dataEl.textContent);
    const units = new Map(data.units.map(u => [u.id, u]));
    const categoryOrder = data.categories;
    let entries = data.entries.filter(id => units.has(id));

    const $ = sel => form.querySelector(sel);
    const factionSelect = $('[data-faction-select]');
    const limitInput = $('[data-limit-input]');
    const entriesEl = $('[data-entries]');
    const entriesEmpty = $('[data-entries-empty]');
    const entryCount = $('[data-entry-count]');
    const pickerRows = [...form.querySelectorAll('.unit-row[data-item]')];
    const pickerSearch = $('[data-picker-search]');
    const pickerCategory = $('[data-picker-category]');
    const pickerHint = $('[data-picker-hint]');
    const pickerEmpty = $('[data-picker-empty]');
    const hiddenEntries = $('[data-hidden-entries]');

    const limit = () => Math.max(0, parseInt(limitInput.value, 10) || 0);
    const total = () => entries.reduce((sum, id) => sum + units.get(id).points, 0);
    const plural = (n, word) => `${n} ${word}${n === 1 ? '' : 's'}`;

    function el(tag, className, text) {
        const node = document.createElement(tag);
        if (className) node.className = className;
        if (text !== undefined) node.textContent = text;
        return node;
    }

    function stepButton(label, attr, id, ariaLabel) {
        const b = el('button', 'btn btn-sm btn-outline-light', label);
        b.type = 'button';
        b.setAttribute(attr, id);
        b.setAttribute('aria-label', ariaLabel);
        return b;
    }

    function renderEntries() {
        const counts = new Map();
        entries.forEach(id => counts.set(id, (counts.get(id) || 0) + 1));

        const sorted = [...counts.keys()].map(id => units.get(id)).sort((a, b) =>
            categoryOrder.indexOf(a.category) - categoryOrder.indexOf(b.category) || a.name.localeCompare(b.name));

        entriesEl.replaceChildren();
        let currentCategory = null;
        sorted.forEach(u => {
            if (u.category !== currentCategory) {
                currentCategory = u.category;
                entriesEl.appendChild(el('h3', 'entry-group-title', u.category));
            }
            const n = counts.get(u.id);
            const row = el('div', 'entry-row');

            const info = el('div', 'entry-info');
            info.appendChild(el('div', 'entry-name', u.name));
            info.appendChild(el('div', 'entry-meta', `${u.points} pts each`));

            const stepper = el('div', 'qty-stepper');
            stepper.appendChild(stepButton('−', 'data-remove-one', u.id, `Remove one ${u.name}`));
            stepper.appendChild(el('span', 'qty', `×${n}`));
            stepper.appendChild(stepButton('+', 'data-add-unit', u.id, `Add another ${u.name}`));

            row.append(info, stepper, el('div', 'entry-points', `${n * u.points} pts`));
            entriesEl.appendChild(row);
        });

        entriesEmpty.classList.toggle('d-none', entries.length > 0);
        entryCount.textContent = plural(entries.length, 'unit');
    }

    function renderPoints() {
        const t = total();
        const l = limit();
        const over = l > 0 && t > l;
        const pct = l > 0 ? Math.min(100, Math.round(t / l * 100)) : 0;

        form.querySelectorAll('[data-total]').forEach(n => n.textContent = t);
        form.querySelectorAll('[data-limit]').forEach(n => n.textContent = l);
        form.querySelectorAll('[data-points-panel]').forEach(p => p.classList.toggle('is-over', over));

        const progress = $('[data-points-progress]');
        progress.setAttribute('aria-valuenow', pct);
        progress.querySelector('.progress-bar').style.width = pct + '%';

        $('[data-points-status]').textContent = over
            ? `${t - l} points over the limit`
            : `${l - t} points left`;
    }

    function renderPicker() {
        const faction = factionSelect.value;
        const q = pickerSearch.value.trim().toLowerCase();
        const category = pickerCategory.value;
        let shown = 0;
        pickerRows.forEach(row => {
            const d = row.dataset;
            const ok = faction !== '' && d.faction === faction
                && (!q || d.name.includes(q))
                && (!category || d.category === category);
            row.classList.toggle('d-none', !ok);
            if (ok) shown++;
        });
        pickerHint.classList.toggle('d-none', faction !== '');
        pickerEmpty.classList.toggle('d-none', faction === '' || shown > 0);
    }

    function render() {
        renderEntries();
        renderPoints();
    }

    form.addEventListener('click', e => {
        const add = e.target.closest('[data-add-unit]');
        if (add) {
            entries.push(Number(add.dataset.addUnit));
            render();
            return;
        }
        const remove = e.target.closest('[data-remove-one]');
        if (remove) {
            const i = entries.lastIndexOf(Number(remove.dataset.removeOne));
            if (i >= 0) entries.splice(i, 1);
            render();
            return;
        }
        const preset = e.target.closest('[data-set-limit]');
        if (preset) {
            limitInput.value = preset.dataset.setLimit;
            limitInput.dispatchEvent(new Event('input', { bubbles: true }));
        }
    });

    let lastFaction = factionSelect.value;
    factionSelect.addEventListener('change', () => {
        if (factionSelect.value === lastFaction) return;
        if (entries.length > 0
            && !confirm(`Changing the faction removes all ${plural(entries.length, 'unit')} from this list. Continue?`)) {
            factionSelect.value = lastFaction;
            return;
        }
        entries = [];
        lastFaction = factionSelect.value;
        render();
        renderPicker();
    });

    limitInput.addEventListener('input', renderPoints);
    pickerSearch.addEventListener('input', renderPicker);
    pickerCategory.addEventListener('input', renderPicker);

    form.addEventListener('submit', () => {
        hiddenEntries.replaceChildren();
        entries.forEach((id, i) => {
            const input = document.createElement('input');
            input.type = 'hidden';
            input.name = `Input.Entries[${i}].UnitId`;
            input.value = id;
            hiddenEntries.appendChild(input);
        });
    });

    render();
    renderPicker();
})();
