const sect_2 = body.querySelector(".sect-2");
const box_select_item = sect_2.querySelectorAll(".box-select-item");

const fix_wd_box_select_item = () => {
  box_select_item.forEach((item) => {
    const list_mod = item.querySelector(".list-mod");
    const wd = list_mod.getBoundingClientRect().width;
    item.style = `--wd-box--si: ${wd}px`;
  });
};
fix_wd_box_select_item();

$(document).ready(function () {
  const box_select_item_click = () => {
    $(".sect-2 .box-select-item").each(function () {
      const content = $(this).find(".content");
      $(content).on("click", function (e) {
        let chevron = $(this).find(".chevron");
        let name = chevron.attr("name");
        if (name === "chevron-down-outline") {
          content.parent().addClass("show");
          chevron.remove();
          $("<ion-icon>", {
            class: "chevron",
            name: "chevron-up-outline",
          }).appendTo($(this));
        } else {
          content.parent().removeClass("show");
          chevron.remove();
          $("<ion-icon>", {
            class: "chevron",
            name: "chevron-down-outline",
          }).appendTo($(this));
        }
      });

      const mod_item_ct = $(".list-mod .mod-item .mod-item-ct");
      mod_item_ct.each(function () {
        let item_each = $(this);
        item_each.on("click", function () {
          content.find("span").html($(this).html());
          content.click();
          $(this).addClass("selected-ct");
          mod_item_ct.each(function () {
            if (!$(this).is(item_each) && $(this).hasClass("selected-ct")) {
              $(this).removeClass("selected-ct");
            }
          });
        });
      });
    });
  };
  box_select_item_click();
});
