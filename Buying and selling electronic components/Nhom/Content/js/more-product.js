

const more_product = () => {
  $(document).ready(function () {
    const add_more_details = () => {
      const f2 = $("#mch .f2");
      const btn_m_attr = f2.find(".btn-m-attr");
      const more_cont = btn_m_attr.siblings(".item");
      btn_m_attr.on("click", function () {
        $("<li>", {
          class: "item-more",
          html: `
            <p class="i1">
              <input
                type="text"
                placeholder="Tên thuộc tính:"
                name="ttt"
              />
            </p>
            <p class="i2">
              <input
                type="text"
                placeholder="Nội dung thuộc tính:"
                name="ndtt"
              />
            </p>
            <p class="del-item">
              <i class="ph ph-x"></i>
            </p>
          `,
        }).appendTo(more_cont);
        const item_more = more_cont.find(".item-more");
        const del = $(item_more[item_more.length - 1]).find(".del-item");
        del.on("click", function () {
          $(this).parent().remove();
        });
      });
    };
    add_more_details();

    const del_details_node = () => {
      const ic_del = $("#mch .f2 .item .item-more .del-item");
      ic_del.each(function () {
        $(this).on("click", function () {
          $(this).parent().remove();
        });
      });
    };
    del_details_node();

    const ops_repair = () => {
      const bo = $(".b-ops");
      const ff = $("#mch .ff");
      bo.find("button").each(function (index) {
        $(this).on("click", function () {
          const rdo = $(this).hasClass("rdo");
          if (!rdo) {
            $(this).addClass("rdo");
            $(this).siblings(".rdo").removeClass("rdo");
            $(ff[index]).siblings(".ff").addClass("dnone");
            $(ff[index]).removeClass("dnone");
          }
        });
      });
    };
    ops_repair();

    const more_files = () => {
      const bmf = $(".btn-m-f");
      const img_s = bmf.siblings(".img-s");
      bmf.on("click", function () {
        let exists_empty_file = false;
        const ip_f = $(this).siblings(".ip-f");
        const f = ip_f.find("input[type=file]");
        if (f.length != 0) {
          f.each(function () {
            if ($(this).val() == "") {
              exists_empty_file = true;
              $(this).click();
              // (*) file trước đó đã tồn tại và đã được gán event load file sẵn
              // nên không cần phải gán lại
            }
          });
        }
        if (!exists_empty_file) {
          const new_file = $("<input>", {
            type: "file",
            class: "files",
            // name: `files_${f.length}`,
            name: "file",
          });
          new_file.appendTo(ip_f);
          new_file.click();

          // (*) => Đây nè
          new_file.on("change", function (e) {
            // console.log(e);
            // ** Lý do tại sao không sử dụng đối tượng $(this) để ánh xạ đến thân chủ hiện tại
            // => Vì Jquery khác, JS thuần khác
            // *=> Chỉ có cách giống nhau là lấy ra target từ thẻ bị tác động bởi sự kiện (event)
            // => Từ đó ánh xạ đến các thuộc tính cần sử dụng
            load_img(e.target, (result_f) => {  
              const li = $("<li>", {
                html: `
                  <img
                    src="${result_f}"
                    alt=""
                  />
                  <p class="del-img">
                    <i class="ph ph-x"></i>
                  </p>
                `,
              });
              li.appendTo(img_s);

              const ip_f = bmf.siblings(".ip-f");
              const li_li = img_s.find("li");
              const del_img = $(li_li[li_li.length - 1]).find(".del-img");
              del_img.on("click", function () {
                const li_li = img_s.find("li");
                let f = ip_f.find("input[type=file]");
                const len = li_li.length;
                let i = 0;
                while (i < len) {
                  if ($(li_li[i]).is($(this).parent())) {
                    $(this).parent().remove();
                    $(f[i]).remove();
                    break;
                  }
                  i++;
                }

                // f = ip_f.find("input[type=file]");
                // for (i = 0; i < f.length; i++) {
                //   $(f[i]).attr("name", `files_${i}`);
                // }
              });
            });
          });
        }
      });
    };
    more_files();

    const load_img = (item, create_img) => {
      var fReader = new FileReader();
      fReader.readAsDataURL(item.files[0]);
      fReader.onload = (e) => {
        create_img(e.target.result);
        // console.log(e);
      };
    };

    const del_file_img = () => {
      const f1 = $("#mch .f1");
      const img_s = f1.find(".img-load .img-s");
      const ip_f = f1.find(".img-load .ip-f");
      const ic_del = img_s.find("li .del-img");
      ic_del.each(function () {
        $(this).on("click", function () {
          const li_li = img_s.find("li");
          let f = ip_f.find("input[type=file]");
          console.log(f);
          const len = li_li.length;
          let i = 0;
          while (i < len) {
            if ($(li_li[i]).is($(this).parent())) {
              $(this).parent().remove();
              $(f[i]).remove();
              break;
            }
            i++;
          }
        });
      });
    };
    del_file_img();

    const add_new_product = () => {
      const mch = $("#mch");
      const btn = mch.siblings(".smf");
      btn.on("click", function (e) {
        e.preventDefault();
        const ID = mch.find("input[name=id]").val();
        const name_prod = mch.find("input[name=tenSP]").val().trim();
        const pr = mch.find("input[name=price]").val().trim();
        const attr = mch.find("input[name=attr]").val().trim();
        const loaiSP = mch.find("select[name=loaiSP]").val().trim();
        const status = mch.find("select[name=Status]").val();
        const sl = mch.find("input[name=sl]").val().trim();
        const code = mch.find("input[name=code").val().trim();
        const ttt = mch.find("input[name=ttt]");
        const ndtt = mch.find("input[name=ndtt");
        let Product_Details = new Array();
        for (let i = 0; i < ttt.length; i++) {
          Product_Details.push({
            Title: $(ttt[i]).val().trim(),
            Content: $(ndtt[i]).val().trim(),
          });
        }
        let product = {
          ID: ID != undefined ? ID : -1,
          Name: name_prod,
          Price: pr,
          Status: status != undefined ? status.trim() : "Còn hàng",
          Attribute: attr,
          ID_Type: loaiSP,
          Count: sl,
          Code: code,
          Product_Details: Product_Details,
        };

        const add = mch.hasClass("add");
        const fetch_url = add
          ? "/load/api/add-new-product"
              : "/load/api/fix-product";

        fetch(fetch_url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json; charset=utf-8",
          },
          body: JSON.stringify(product),
        })
            .then((res) => res.json())
            .then(async (data) => {
            console.log(data);
              if (data.Status == "Success") {

                  let url_set_session = add ? '/load/api/type-update-product?type=add' : '/load/api/type-update-product?type=update';

                  await fetch(url_set_session);

                let myfile = $("#mch .img-load .ip-f input[type=file]");
                let formData = new FormData();
                for (let i = 0; i < myfile.length; i++) {
                    formData.set("file_" + i, myfile[i].files[0]);
                 }

              fetch("/load/api/add-files-img", {
                method: "POST",
                body: formData,
                contentType: false,
                processData: false,
              }).then((res) =>
                res.json().then((dt) => {
                  mess_box_show(dt.Status, dt.Content).appendTo($("section"));
                    btn_click_ok(dt.Status, add);
                  $("body").addClass("ov-y-hd");
                })
              );
            } else {
                  mess_box_show(data.Status, data.Content).appendTo($("section"));
                  btn_click_ok(data.Status, add);
              $("body").addClass("ov-y-hd");
            }
          });
      });
    };
    add_new_product();

    const mess_box_show = (status, content) => {
      // alert(status + "/" + content);
      let i =
        status == "Success"
          ? '<ion-icon name="checkbox"></ion-icon>'
          : '<ion-icon name="warning"></ion-icon>';
        let done = status == "Success" ? "st-ss" : "";
      const mess = $("<div>", {
        class: "mess-box--ss",
        html: `
          <div class="mess-box">
            <p class="status ${done}">
              ${i}
              Thông báo
            </p>
            <p class="content">
              ${content}
            </p>
            <p class="btn-s">
              <button class="ok">ok</button>
            </p>
          </div>
          `,
      });
      return mess;
    };

    const btn_click_ok = (status, add) => {
      $(document).on("click", ".mess-box--ss .btn-s .ok", function () {
        if (status == "Success" && add) {
          $(".b-ops .prod-mod").click();
          $("#mch .f1 input").each(function () {
            $(this).val("");
          });
          $("#mch .f1 select").val($(this).find("option:first-child").html());
          $(".img-load .ip-f").empty();
          $(".img-load .img-s").empty();
          $("#mch .f2 .item").empty();
        }

          if (status == "Success" && !add) window.location.href = window.location.href;

        $(this).closest(".mess-box--ss").remove();
        $("body").removeClass("ov-y-hd");
      });
    };
  });
};
more_product();

const import_file_to_input = async () => {
  const mch = document.querySelector("#mch");
  const f1 = mch.querySelector(".f1");
  const img_load = f1.querySelector(".img-load");
  const ip_f = f1.querySelector(".ip-f");
  const all_img_in_img_load = img_load.querySelectorAll("img");
  if (all_img_in_img_load.length > 0) {
    const get_el = new Array();
    all_img_in_img_load.forEach((item) => {
      get_el.push(item);
    });
    const fetch_load_map = get_el.map((item) => fetch(item.currentSrc));
     //console.log(fetch_load_map);
    const Promise_Fetch = await Promise.all(fetch_load_map);
     //console.log(Promise_Fetch);
      const Blob_from_Respone = await Promise_Fetch.filter((item) => item.blob());
     //console.log(Blob_from_Respone);
    const Promise_Blob = await Promise.all(Blob_from_Respone);
     //console.log(Promise_Blob);
    for (let i = 0; i < Promise_Blob.length; i++) {
      const input = document.createElement("input");
      input.type = "file";
      input.classList.add("files");

      let src_split = get_el[i].src.split("/");
       //console.log(src_split);
      let file_name = src_split[src_split.length - 1];
       //console.log(file_name);
      let file = new File([Promise_Blob[i]], file_name, {
        type: Promise_Blob[i].type,
        size: Promise_Blob[i].size,
      });
      //console.log(file);
      let data_file = new DataTransfer();
      data_file.items.add(file);
       //console.log(data_file);
      input.files = data_file.files;
       //console.log(input);
      ip_f.appendChild(input);
    }
  }
};
import_file_to_input();
