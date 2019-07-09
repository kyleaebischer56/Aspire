function clearAndAddOptionsToSelect(selectListId, options) {
    let selectListElement = document.getElementById(selectListId);

    selectListElement.options.length = 0;

    options.forEach((option) => {
        var optionElement = document.createElement('option');

        optionElement.text = option.text;
        optionElement.value = option.value;
        optionElement.disabled = option.disabled;
        optionElement.selected = option.selected;

        selectListElement.add(optionElement);
    });
}