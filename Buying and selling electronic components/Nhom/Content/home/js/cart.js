$(document).ready(function () {
  const cart = $(".cart .cart-list .list-pr");
  const card = $(".sect-card .box .grid-box .card");
  const count_pr_cart_ic = $("header .s-log .cart-ic span");
  const total_el = $(".cart .box .total-pri");

  const get_count_cart = () => {
    let count = 0;
    cart.find(".pr-item").each(function () {
      count += parseInt($(this).find(".num-pr").val());
    });
    return count;
  };

  const cal_total = () => {
    const pr_item = cart.find(".pr-item");
    let total = 0;
    pr_item.each(function () {
      const mon = $(this).find(".price-cou span:first-child");
      const mon_sp = mon.html().split(",");
      const unify_mon = parseFloat(
        mon_sp[0] + mon_sp[1] + mon_sp[2].split("&nbsp;")[0]
      );
      const count = $(this).find(".num-pr");
      const tt = unify_mon * count.val();
      total += tt;
    });
    return total;
  };

  const num_to_money = (mon) => {
    const len = mon.toString().length;
    console.log(len);
    let cou = 1;
    let str_mon = mon.toString();
    for (let i = len - 1; i >= 0; i--) {
      if (cou % 3 == 0 && i != 0) {
        str_mon = str_mon.substring(0, i) + "," + str_mon.substring(i);
      }
      cou++;
    }
    return str_mon;
  };

  const filter_cart = (name_pr) => {
    const pr = cart.find(".pr-item");
    return pr.filter((index) => {
      return $(pr[index]).find(".name-pr").html().trim() === name_pr;
    });
  };

  //add product to cart
  const add_pro_to_cart = () => {
    card.each(function () {
      const btn_add_cart = $(this).find(".btn-link-more button");
      const pic = $(this).find(".pic");
      const img = pic.find("img");
      const name = $(this).find(".tit-c");
      const price = $(this).find(".heart-prc p");
      btn_add_cart.on("click", function () {
        const exist_pr = filter_cart(name.html());
        if (exist_pr.length > 0) {
          const cou_pr = $(exist_pr[0]).find(".num-pr");
          cou_pr.val(parseInt(cou_pr.val()) + 1);

          total_el.html(num_to_money(cal_total()));
          count_pr_cart_ic.html(get_count_cart());
          change_val_cou_pr();
          return;
        }
        const str_cart_item = `
          <figure>
            <input class="c-b" type="checkbox" name="" />
            <img
              src="${img[0].src}"
              alt=""
            />
            <div class="right">
              <p class="name-pr">
                ${name.html()}
              </p>
              <p class="price-cou">
                <span>${price.html()}</span>
                <span
                  >SL:&nbsp;
                  <input
                    type="number"
                    class="num-pr"
                    value="1"
                    min="1"
                    max="100"
                  />
                </span>
              </p>
            </div>
            <p class="del-pr">xóa</p>
          </figure>
        `;

        const cart_item = $("<li>", {
          html: str_cart_item,
          class: "pr-item",
        });
        cart_item.appendTo(cart);

        total_el.html(num_to_money(cal_total()));
        count_pr_cart_ic.html(get_count_cart());
        change_val_cou_pr();
      });
    });
  };
  add_pro_to_cart();

  const change_val_cou_pr = () => {
    const num_pr = cart.find(".pr-item .num-pr");
    num_pr.each(function () {
      const del_item = $(this).closest(".right").siblings(".del-pr");
      del_item.on("click", function () {
        $(this).parent().parent().remove();
        const total_mon = cal_total();

        total_mon != 0
          ? total_el.html(num_to_money(cal_total()))
          : total_el.html(0);

        total_el.html(num_to_money(cal_total()));
        count_pr_cart_ic.html(get_count_cart());
      });

      $(this).off("change");
      $(this).on("change", function () {
        total_el.html(num_to_money(cal_total()));
        count_pr_cart_ic.html(get_count_cart());
      });

      $(this).off("keyup");
      $(this).on("keyup", function () {
        if ($(this).val() < 1) {
          $(this).val(1);
        }

        if ($(this).val() > 100) {
          $(this).val(100);
        }

        total_el.html(num_to_money(cal_total()));
        count_pr_cart_ic.html(get_count_cart());
      });
    });
  };

  const cart_ic_click = () => {
    $(".s-log .cart-ic").on("click", function () {
      let has = $(".cart").hasClass("open");
      if (!has) {
        $(".cart").addClass("open");
        $("body").addClass("overflow-hd");
      }
    });
  };
  cart_ic_click();

  const close_ic_cart_click = () => {
    $(".cart .box .close").on("click", function () {
      let has = $(".cart").hasClass("open");
      if (has) {
        $(".cart").removeClass("open");
        $("body").removeClass("overflow-hd");
      }
    });
  };
  close_ic_cart_click();

  const all_cb_click = () => {
    $(".cart .box .all-cb").on("click", function () {
      $(".list-pr .pr-item").each(function () {
        let item = $(this);
        let checkBox = item.find("figure").find(".c-b");
        if (!checkBox.prop("checked")) {
          checkBox.prop("checked", true);
        }
      });
    });
  };
  all_cb_click();

  const cancel_all_cb_click = () => {
    $(".cart .box .rmv-cb").on("click", function () {
      $(".list-pr .pr-item").each(function () {
        let item = $(this);
        let checkBox = item.find("figure").find(".c-b");
        if (checkBox.prop("checked")) {
          checkBox.prop("checked", false);
        }
      });
    });
  };
  cancel_all_cb_click();
});
