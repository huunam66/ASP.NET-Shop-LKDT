const saving = [];

const save = () => {
  const tbody = document.querySelector("tbody");
  const tr = tbody.querySelectorAll("tr");
  tr.forEach((item) => {
    saving.push(item);
  });
};
save();
// console.log(saving[0].innerHTML);

const product_type_select = () => {
  const more = document.querySelector(".layout .more");
  // console.log(more);
  const select = more.querySelector("select[name=typing]");
  const submit = select.parentNode.querySelector("button[type=submit]");
  select.addEventListener("change", () => {
    submit.click();
    // console.log(submit);
  });
};
product_type_select();

const search_product_input = () => {
  const more = document.querySelector(".layout .more");
  const search_p = more.querySelector(".search-p");
  const select = more.querySelector("select[name=typing]");
  const input_search = search_p.querySelector("input[name=search]");
  const childNodes_select = select.childNodes;
  let type_option = 1;
  for (let i = 0; i < childNodes_select.length; i++) {
    // console.log(childNodes_select[i].value);
    if (childNodes_select[i].selected) {
      type_option = childNodes_select[i].value;
      break;
    }
  }
  // console.log(type_option);

  const tbody = document.querySelector("tbody");
  input_search.addEventListener("keyup", (e) => {
    tbody.innerHTML = ``;
    let _this = e.target;
    if (_this.value == "") {
      saving.forEach((item) => {
        tbody.appendChild(item);
      });
    } else {
      fetch_search(tbody, _this.value.trim(), type_option);
    }
  });
};

const create_tr_el = (item) => {
  const tr = document.createElement("tr");
  tr.innerHTML = `
          <td class="st" scope="row">
              <img class="pics" src="/Content/img/${item.Assests[0].folder}/${item.Assests[0].file_name}">
          </td>
          <td class="st st-1" name="id" scope="row">${item.ID}</td>
          <td class="name st st-2" name="name" scope="row">${item.Name}</td>
          <td scope="row">${item.Price}</td>
          <td scope="row">${item.Attribute}</td>
          <td scope="row">${item.Count}</td>
          <td scope="row">${item.Status}</td>
          <td scope="row">${item.Product_Type}</td>
          <td scope="row">${item.Code}</td>
          <td class="ops" scope="row">
              <a class="fix" href="/Manage/Fix_Product?id=${item.ID}" title="Chỉnh sửa">
                  <img src="/Content/img/sys/update.png">
              </a>
              <a class="del" title="Xóa">
                  <img src="/Content/img/sys/delete.png">
              </a>
          </td>
        `;
  return tr;
};

const fetch_search = async (tbody, value, type_option) => {
  const fetch_ran = [
      $.ajax({
          url: "/load/api/search/admin/product",
          type: "POST",
          contentType: "application/json",
      data: JSON.stringify({
        type: type_option,
        content: value,
      }),
    }),
  ];
  const Promise_fetch = await Promise.all(fetch_ran);
  //const mapping_Respone_Promise = Promise_fetch.map((item) => item.json());
    const Promise_Respone_Json = await Promise.all(Promise_fetch);
  const mapping_result = Promise_Respone_Json.map((item) => item.result);
  mapping_result[0].result.forEach((item) => {
    console.log(item);
    tbody.appendChild(create_tr_el(item));
    const last_child_tr = tbody.lastChild;
    const ic_del = last_child_tr.querySelector("a[class=del]");
    event_del_ic(ic_del);
  });
};
search_product_input();

const event_del_ic = (ic_del) => {
  ic_del.addEventListener("click", function (e) {
    const _this = e.target;
    const pr = _this.parentNode;
    const tr = pr.parentNode.parentNode;
    const id = tr.querySelector("td[name=id]");
    const name = tr.querySelector("td[name=name]");
    let mess_box = document.createElement("div");
    mess_box.classList.add("mess-box--ss");
    mess_box.innerHTML = `
      <div class="mess-box">
        <p class="status qs-del">
          <ion-icon name="help-circle"></ion-icon>
          Bạn muốn ?
        </p>
        <p class="content">
          Xóa sản phẩm <span name="qs-qs">${name.innerHTML}</span> ?
        </p>
        <p class="btn-s">
          <button class="ok" name="ok">ok</button>
          <button class="cancl cancl-del" name="cancel">hủy bỏ</button>
        </p>
      </div>
    `;

    const body = document.querySelector("body");
    const box_table = document.querySelector(".box-table");
    box_table.appendChild(mess_box);
    body.classList.add("ov-y-hd");
    mess_box = box_table.querySelector(".mess-box--ss");
    const ok_btn = mess_box.querySelector("button[name=ok]");
    const cancel_btn = mess_box.querySelector("button[name=cancel]");
    cancel_btn.addEventListener("click", () => {
      mess_box.remove();
      body.classList.remove("ov-y-hd");
    });

    ok_btn.addEventListener("click", () => {
      // console.log(id.innerHTML);
        $.ajax({
            url: `/load/api/delete/product/admin/${id.innerHTML}`,
            type: "DELETE",
            success: (result) => {
                console.log(result);
                const status = mess_box.querySelector(".status");
                const content = mess_box.querySelector(".content");
                const btn_s = mess_box.querySelector(".btn-s");
                cancel_btn.classList.add("dnone");
                status.classList.remove("qs-del");
                if (result.Status == "Success") {
                    const currentLocation = window.location.href;
                    status.classList.add("st-ss");
                    status.innerHTML = `
                  <ion-icon name="checkbox"></ion-icon>
                  ${result.Status}
                `;
                    content.innerHTML = `
                  Xóa sản phẩm <span name="del-ss">${name.innerHTML}</span> thành công !
                `;
                    btn_s.innerHTML = `
                  <a class="ok" name="ok" href="${currentLocation}">ok</a>
                `;
                } else {
                    status.classList.add("st-fail");
                    status.innerHTML = `
                  <ion-icon name="bug"></ion-icon>
                  Lỗi !
                `;
                    content.innerHTML = `
                  Xóa sản phẩm <span>${name.innerHTML}</span> thất bại !
                `;
                    btn_s.innerHTML = `
                  <button class="ok" name="cancel">OK</button>
                `;
                    btn_s.querySelector(".ok").addEventListener("click", () => {
                        mess_box.remove();
                        body.classList.remove("ov-y-hd");
                    });
                }
            }
        });
    });
  });
};

const select_page = () => {
  const select = document.querySelector(".page-off select");
  if (select != null) {
    const br = select.parentNode.querySelector("button");
    select.addEventListener("change", (e) => {
      br.click();
    });
  }
};
select_page();

const delete_product_admin = () => {
  const tbody = document.querySelector("tbody");
  const tr = tbody.querySelectorAll("tr");
  tr.forEach((item) => {
    const ic_del = item.querySelector(".del");
    event_del_ic(ic_del);
  });
};
delete_product_admin();
