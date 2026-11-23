// Shared scripts for every page.

// <select data-autosubmit> submits its form as soon as the value changes (e.g. the game system picker).
document.addEventListener('change', e => {
    if (e.target.matches('select[data-autosubmit]')) {
        e.target.form?.submit();
    }
});
