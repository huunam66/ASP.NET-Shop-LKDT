const body = document.querySelector("body");
const header = body.querySelector("header");
let nav_link = header.querySelectorAll(".nav-item");
const nav_link_hov = () => {
  nav_link.forEach((item) => {
    let prod = item.querySelector(".prod");
    if (prod) {
      item.addEventListener("mouseenter", () => {
        prod.classList.remove("d-none");
      });
      item.addEventListener("mouseleave", () => {
        prod.classList.add("d-none");
      });
    }
  });
};
nav_link_hov();

const s_log = header.querySelector(".s-log");
const log = s_log.querySelector(".log");
const user_ic = log.querySelector(".user");
const go = log.querySelector(".go");
const user_ic_hov = () => {
  user_ic.addEventListener("mouseenter", () => {
    go.classList.remove("d-none");
  });
  log.addEventListener("mouseleave", () => {
    go.classList.add("d-none");
  });
};
user_ic_hov();

const search_f = s_log.querySelector(".s");
const input_s = search_f.querySelector(".c-in");
const icon_ic = search_f.querySelector(".btn-ops");
const input_cls_ic = input_s.querySelector("ion-icon");
const icon_ic_click = () => {
  icon_ic.addEventListener("click", () => {
    input_s.classList.remove("d-none");
    input_s.classList.add("d-flex");
  });
  input_cls_ic.addEventListener("click", () => {
    input_s.classList.remove("d-flex");
    input_s.classList.add("d-none");
  });
};
icon_ic_click();

const sticky_header_mk = () => {
  let height_header = header.clientHeight;
  window.addEventListener("scroll", () => {
    new IntersectionObserver((obs) => {
      let height_view_lost = obs[0].boundingClientRect.top;
      if (-height_view_lost >= height_header) {
        body.classList.add("sticky");
      }
      if (-height_view_lost < height_header) {
        body.classList.remove("sticky");
      }
    }).observe(body);
  });
};
sticky_header_mk();

const sect_1 = body.querySelector(".sect-1");
const cont_sect_1 = sect_1.querySelector(".container");
const ct = sect_1.querySelector(".ct");
const flag_ct_on = true;
const flag_ct_off = false;
let flag_ct = flag_ct_off;

const e_ct_mousemove = () => {
  cont_sect_1.addEventListener("mousemove", (e) => {
    if (flag_ct === flag_ct_on) {
      // console.log(client_pos_moudwn);
      // console.log(flag_ct);
      ct.style = `--move-x: ${e.clientX - client_pos_x}px; 
                  --move-y: ${e.clientY - client_pos_y}px`;
    } else {
      // console.log(flag_ct);
      ct.style = `--move-x: 0; --move-y: 0; transition: all .3s !important`;
    }
  });
};
e_ct_mousemove();

const e_ct_mouseleave = () => {
  cont_sect_1.addEventListener("mouseleave", () => {
    ct.style = `--move-x: 0; --move-y: 0; transition: all .3s !important`;
    flag_ct = flag_ct_off;
  });
};
e_ct_mouseleave();

let client_pos_x = null;
let client_pos_y = null;
const e_ct_mousedown = () => {
  ct.addEventListener("mousedown", (e) => {
    client_pos_x = e.clientX;
    client_pos_y = e.clientY;
    flag_ct = flag_ct_on;
  });
};
e_ct_mousedown();

const e_ct_mouseup = () => {
  ct.addEventListener("mouseup", () => {
    flag_ct = flag_ct_off;
  });
};
e_ct_mouseup();
