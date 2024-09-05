const sect_card = body.querySelector(".sect-card");
const grid_box_item_sect_card = sect_card.querySelectorAll(".grid-box-item");
const card = sect_card.querySelectorAll(".card");
const auto_h_gridItem_sect5 = () => {
  for (let key in grid_box_item_sect_card) {
    let h_card = card[key].offsetHeight;
    grid_box_item_sect_card[key].style = `--height-scgr-5: ${h_card}px`;
  }
};

const e_card_hov = () => {
  card.forEach((item) => {
    let img_s = item.querySelectorAll(".pic img");
    let btn_link_more = item.querySelector(".btn-link-more");
    let btn_add_c = btn_link_more.querySelector("button");
    let btn_show_mr = btn_link_more.querySelector("a");
    item.addEventListener("mouseenter", () => {
      if (img_s.length == 2) {
        img_s[0].className = "hide-an";
        img_s[1].className = "show-an";
      }
      btn_add_c.classList.remove("d-none");
      btn_show_mr.classList.remove("d-none");
    });
    item.addEventListener("mouseleave", () => {
      if (img_s.length == 2) {
        img_s[1].className = "hide-an";
        img_s[0].className = "show-an";
      }
      btn_add_c.classList.add("d-none");
      btn_show_mr.classList.add("d-none");
    });
  });
};
e_card_hov();

window.onload = () => {
  auto_h_gridItem_sect5();
};
const e_win_resize = () => {
  window.addEventListener("resize", (e) => {
    auto_h_gridItem_sect5();
  });
};
e_win_resize();
