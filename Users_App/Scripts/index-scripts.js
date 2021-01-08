const removeLink = document.querySelectorAll(".delete");

for (let i = 0; i < removeLink.length; i++) {
    removeLink[i].addEventListener("click", function (event) {
        const tableRows = document.querySelectorAll("table tr");
        const username = tableRows[i + 1].querySelector("td:nth-child(2)").innerHTML;

        const check = window.confirm("Are you sure you want to remove " + username + "?");

        if (!check) {
            event.preventDefault();
        }
    });
}

const searchbox = document.querySelector("input");

searchbox.addEventListener("keyup", function () {
    const tableRows = document.querySelectorAll("table tr");

    for (let i = 1; i < tableRows.length; i++) {
        const inputFilter = searchbox.value.toUpperCase();
        const username = tableRows[i].querySelector("td:nth-child(2)").innerHTML.toUpperCase();

        if (username.search(inputFilter) === -1) {
            tableRows[i].style.display = "none";
        } else {
            tableRows[i].style.display = "table-row";
        }
    }
});
