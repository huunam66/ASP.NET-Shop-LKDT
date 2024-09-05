const select_page = () => {
  const select = document.querySelector(".page-off select");
  const br = select.parentNode.querySelector("button");
  select.addEventListener("change", (e) => {
    br.click();
  });
};
select_page();
