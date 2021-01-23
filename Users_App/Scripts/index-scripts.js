// Search records:
const searchbox = document.querySelector("input");

searchbox.addEventListener("keyup", function () {
    const tableRows = document.querySelectorAll("table tbody tr");

    for (let i = 0; i < tableRows.length; i++) {
        const inputFilter = searchbox.value.toUpperCase();
        const username = tableRows[i].querySelector("td:nth-child(2)").innerHTML.toUpperCase();

        if (username.startsWith(inputFilter, 0) === false) {
            tableRows[i].style.display = "none";
        } else {
            tableRows[i].style.display = "table-row";
        }
    }
});

// Remove records check:
const ajaxLinks = document.querySelectorAll(".delete");

for (let i = 0; i < ajaxLinks.length; i++) {
    ajaxLinks[i].addEventListener("click", function (event) {
        const records = document.querySelectorAll("table tbody tr");
        const username = records[i].querySelector("td:nth-child(2)").innerHTML;

        const check = window.confirm(`Are you sure you want to remove ${username}?`);

        if (!check) {
            event.preventDefault();
            event.stopImmediatePropagation();
        }
    });
}
