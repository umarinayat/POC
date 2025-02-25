window.bootstrapModal = {
    show: (modalId) => {
        const modal = new bootstrap.Modal(document.getElementById(modalId));
        modal.show();
    },
    hide: (modalId) => {
        const modal = bootstrap.Modal.getInstance(document.getElementById(modalId));
        if (modal) {
            modal.hide();
        }
    }
};
