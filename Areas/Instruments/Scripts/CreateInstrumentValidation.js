class CreateInstrumentValidation {
    formIsValid = false;

    constructor() {
        document.getElementById('SerialNumber').addEventListener('change', validateSerialNumber(event));
    }

    validateSerialNumber(event) {
        const value = event.target.value;

        if (value === '') {
            this.formIsValid = false;
        }
    }
}