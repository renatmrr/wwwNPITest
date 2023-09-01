class JsDataParametrs {
    constructor(intId,strEcho, strSearch, intDisplayLength,
        intDisplayStart, intColumns, intSortCol_0, strSortDir_0,
        intSortingCols, strColumns) {
        this.strEcho = strEcho;
        this.strSearch = strSearch;
        this.intDisplayLength = intDisplayLength;
        this.intDisplayStart = intDisplayStart;
        this.intColumns = intColumns;
        this.intSortCol_0 = intSortCol_0;
        this.strSortDir_0 = strSortDir_0;
        this.intSortingCols = intSortingCols;
        this.strColumns = strColumns;
        this.intId = intId
    }

}

const param = new JsDataParametrs(0,"", "", 10, 0, 4, -1, 'asc', 10, ',,,');

const paramT = new JsDataParametrs(0,"", "", 1000, 0, 4, -1, 'asc', 10, ',,,');

const linkGetProjectsCompany = 'api/Values/GetProjectsCompany/' //'/Home/GetProjectsCompany/';

const linkGetProjectsCompanyTable = 'api/Values/GetProjectsCompanyTable/';

const linkGetObjectDesignTable = 'api/Values/GetObjectDesignTable/';

getData(linkGetProjectsCompany, 1, "treeProjectCompany");

async function paginator(link, co, tableId) {
    const paginator = document.getElementById(tableId).getElementsByClassName("pagination")[0];
    if (paginator == null) return;
    paginator.innerHTML = "";
    const count_page = parseInt(co.intTotalRecords) / parseInt(param.intDisplayLength);
    for (let i = 1; i < count_page + 1; i++) {
        const pA = document.createElement("a");
        pA.setAttribute("href", "#" + tableId + "IsPage=" + i);
        pA.addEventListener("click", async () => await getData(link, i, tableId));
        pA.append(i)
        paginator.append(pA);
    }
    const labelTotalRecords = document.getElementById(tableId).getElementsByTagName("label")[0];

    labelTotalRecords.innerText = co.intTotalRecords;
}
async function getData(link, page, elmId, intSortCol_0 = -1) {
    param.intDisplayStart = param.intDisplayLength * page - param.intDisplayLength;

    if (intSortCol_0 >= 0) {
        param.intSortCol_0 = intSortCol_0;
        param.strSortDir_0 = param.strSortDir_0 == "asc" ? "desc" : "asc"
    }

    let elm = document.getElementById(elmId);

    if (elmId == 'treeProjectCompany') {

        elm.innerHTML = "Загрузка";
    }
    if (elmId == 'tableProjectCompany') {
        const rows = elm.querySelector("tbody");

        rows.innerHTML = "Загрузка";
    }

    
    const response = await fetch(link, {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(link == linkGetProjectsCompany ? paramT : param)
    });

    if (response.ok === true) {

        const result = await response.json();

        if (elmId == 'treeProjectCompany') {

            elm.innerHTML = "";

            result.data.forEach(r => elm.append(rowTreeProjects(r, r.name +'(' + r.code + ')', r.id, linkGetProjectsCompanyTable)));
        }
        if (elmId == 'tableProjectCompany') {

            const rows = elm.querySelector("tbody");
         
            rows.innerHTML = "";

            result.data.forEach(r => rows.append(rowTable(r)));

            await paginator(link, result, elmId);


            OrderByInit(link, elmId)

        }
    }
    else {
        const error = await response.json();
        console.log(error.message);
    }
}
function rowTable(r) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", r.id);
   
    const codeTd = document.createElement("td");
    codeTd.append(r.code);
    tr.append(codeTd);

    const codeObjectTd = document.createElement("td");
    codeObjectTd.append(r.codeObject);
    tr.append(codeObjectTd);

    const modelTd = document.createElement("td");
    modelTd.append(r.model);
    tr.append(modelTd);


    const numberTd = document.createElement("td");
    numberTd.append(r.number);
    tr.append(numberTd);

    const fullCodeTd = document.createElement("td");
    fullCodeTd.append(r.fullCode);
    tr.append(fullCodeTd);

    return tr;
}
function rowTreeProjects(line, text, id, link) {

    const ul = document.createElement("ul");

    const li = document.createElement("li");

    ul.append(li);

    const details = document.createElement("details");

    const nameSummary = document.createElement("summary");

    nameSummary.append(text);

    if (id != null) {

        nameSummary.setAttribute("data-id", id);
        nameSummary.onclick = function ()
        {
            param.intId = id;
            getData(link, 1, "tableProjectCompany")
        };
    }

    details.append(nameSummary);

    li.append(details);

    if (line.gDesignObjects != null) {

        line.gDesignObjects.forEach(r => details.append(rowTreeProjects(r, "уровень " + r[0].level)));
    }

    if (Array.isArray(line)) {

        line.forEach(r => details.append(rowTreeProjects(r, r.name + '(' + r.code + ')', r.id, linkGetObjectDesignTable)));
    }

    return ul;
}
function OrderByInit(link, tableId) {
    let table = document.getElementById(tableId);
    let rows = table.querySelectorAll("th");

    for (let i = 0; i < rows.length; i++) {

        rows[i].onclick = function () {
            getData(link, 1, tableId, i)
        }
    }
}
