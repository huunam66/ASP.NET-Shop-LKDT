const detail_prod = () => {
  $(document).ready(function () {
    const swipe_img_list = () => {
      const list_img = $(".img-pos .list-img");
      let get_x_down = 0;
      let cur_swipe_out = 0;
      let move = 0;
      let flag_off = false;
      let flag_on = true;
      let flag_e = flag_off;
      let li_item = list_img.find("li");
      list_img.on("mousedown", function (e) {
        get_x_down = e.clientX;
        flag_e = flag_on;
        // console.log(get_x_down);
      });
      list_img.on("mousemove", function (e) {
        if (flag_e == flag_on) {
          // console.log(e.clientX);
          let move_x = e.clientX - get_x_down;
          move = move_x;
          if (cur_swipe_out != 0) {
            if (e.clientX > 0) {
              move = cur_swipe_out + move_x;
            } else {
              move = cur_swipe_out - move_x;
            }
          }
          if (move > 0) {
            move = 0;
          }
          li_item.each(function () {
            $(this).css("--move--x", move + "px");
            console.log($(this).width());
          });
        }
      });
      list_img.on("mouseup", function (e) {
        cur_swipe_out = move;
        flag_e = flag_off;
      });
      list_img.on("mouseleave", function (e) {
        if (flag_e == flag_on) {
          cur_swipe_out = move;
        }
        flag_e = flag_off;
      });
    };
    swipe_img_list();
  });
};
detail_prod();

const event_img = () => {
  const img_big = document.querySelector(".img-big picture img");
  const li_item = document.querySelectorAll(".list-img li");
  li_item.forEach((item) => {
    item.addEventListener("mouseup", (e) => {
      const img = item.querySelector("picture img");
      img_big.src = img.src;
      item.classList.add("bdr-1-2455d3");
      for (let i = 0; i < li_item.length; i++) {
        if (
          li_item[i].classList.contains("bdr-1-2455d3") &&
          !li_item[i].isSameNode(item)
        ) {
          li_item[i].classList.remove("bdr-1-2455d3");
          break;
        }
      }
    });
  });
};
event_img();


const btn_add_cart = document.querySelector('button[class="btn-add-cart"]');
btn_add_cart.addEventListener('click', async (e) => {
    let id = e.target.getAttribute('id-set');
    let request = '/load/api/cart/add/' + id;

    let result = null;
    await fetch(request)
        .then(res => res.json())
        .then(res => result = res)
        .catch(ex => result = ex);
    
    if (result != null && result.http_status != null) {
        mess_box(result);
        update_size_cart(result.cart_size);
        console.log(result);
    }
})


const mess_box = (result) => {
    const body = document.querySelector('body');
    let mess_site = document.querySelector('.mess-site');
    if (mess_site != null) document.removeChild(mess_site);
    mess_site = document.createElement('div');
    mess_site.className = 'mess-site';
    mess_site.innerHTML = `
                            <div class="mess-box">
                                <p class="mess-text" style="color: ${result.color}">${result.status}</p>
                                <img type="hidden" style="display: none;" src="${result.sta_tic}">
                                <img class="ic-ss" src="${result.gif}">
                            </div>
                        `;
    body.appendChild(mess_site);
    setTimeout(() => {
        $('.mess-box img')
            .attr('src', () => {
                return $('.mess-box img[type=hidden]').attr('src');
            })
        $('.mess-box img[type=hidden]').remove();
        setTimeout(() => {
            $('.mess-site').remove();
            body.classList.remove('ov-hd');
        }, 600)
    }, 1200);
}

const update_size_cart = (size) => {
    const ic_size = document.querySelector('.cart .num');
    ic_size.innerHTML = size;
}