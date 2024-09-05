

const Format_Price = (text) => {
    let left_price = text.includes('.') ? price.split('.')[0] : text;
    let len = left_price.length;
    let jump = 0;
    for (let i = len - 1; i >= 0; i--)
    {
        if (jump % 2 == 0 && jump != 0 && i != 0)
        {
            left_price = left_price.substring(0, i) + "." + left_price.substring(i);
            i--;
        }
        jump++;
    }
    return left_price;
}

const update_count = (e) => {
    let price = e.target.parentNode.parentNode.querySelector('.price .pri').getAttribute('data-price');
    let count = e.target.value;
    
    let total_el = e.target.parentNode.parentNode.querySelector('.total .pri');
    let total = parseFloat(price) * parseInt(count);
    total_el.innerHTML = Format_Price(total.toString());
}

const update_total_countall = () => {
    const counter_all = document.querySelectorAll('.counter input[type=number]');
    const counter_sum_el = document.querySelector('.sum-cout .rest-rt');
    const total_el = document.querySelector('.sum-cout .total-mon-rt');
    let total = 0;
    let counter_sum = 0;

    counter_all.forEach(item => {
        let price = item.parentNode.parentNode.querySelector('.price .pri').getAttribute('data-price');
        price = parseFloat(price.includes('.') ? price.split('.')[0] : price);
        let num = parseInt(item.value);
        counter_sum += num;
        total += (price * num);
    })
    counter_sum_el.innerHTML = counter_sum;
    total_el.innerHTML = Format_Price(total.toString());
}

const update_count_prod_child = (cart) => {
    const iem_prod = document.querySelectorAll('#cart-pay .item');
    iem_prod.forEach(item => {
        let checkbox = item.querySelector('input[type=checkbox]');
        if (checkbox != null) {
            checkbox.addEventListener('change', (e) => {
                if (e.target.checked) {
                    e.target.parentNode.classList.add('ch-item-c');
                }
                else {
                    e.target.parentNode.classList.remove('ch-item-c');
                }
            })
        }

        let counter = item.querySelector('.counter input[type=number]');
        counter.addEventListener('change', (e) => {
            if(cart) update_count_prod(e);
            update_count(e);
            update_total_countall();
        });
        counter.addEventListener('keyup', (e) => {
            if (e.target.value == '' || e.target.value < 1) {
                e.target.value = 1;
            }
            if (e.target.value > parseInt(e.target.getAttribute('max'))) {
                e.target.value = e.target.getAttribute('max');
            }
            if (cart) update_count_prod(e);
            update_count(e);
            update_total_countall();
        });

    })
}

const select_all = document.querySelector('input[name="select-all"]');
if (select_all !== null) {
    select_all.addEventListener('change', (e) => {
        const checkbox_all = document.querySelectorAll('.ch-item');
        checkbox_all.forEach(item => {
            item.checked = e.target.checked;
            if (item.checked) {
                item.parentNode.classList.add('ch-item-c');
            }
            else {
                item.parentNode.classList.remove('ch-item-c');
            }
        })
    })
}


const host = 'https://localhost:44340';
const config = {
    "headers": {
        "content-type": "application/json"
    }
}

const btn_pay = document.querySelector('.btn-buy button[name=paying]');
if (btn_pay !== null) {
    btn_pay.addEventListener('click', async (e) => {
        const request = '/load/api/pay';
        let request_document = [];

        const checkbox_all = document.querySelectorAll('.ch-item');
        checkbox_all.forEach(item => {
            if (item.checked) {
                let product_id = item.value;
                let product_count = item.parentNode.querySelector('.counter input[type=number]').value;

                request_document.push({
                    product_id: parseInt(product_id),
                    product_count: parseInt(product_count)
                })
            }
        })

        console.log(request_document);

        let result = null;
        await fetch(host + request, {
            method: 'POST',
            headers: config,
            body: JSON.stringify(request_document)
        })
            .then(res => res.json())
            .then(res => result = res)
            .catch(ex => result = ex);

        console.log(result);

        if (result != null && result.error != null) {
            alert(result.error);
        }

        window.location.href = host + result.url;
    })

    update_count_prod_child(true);

    const del_prod_item = document.querySelectorAll('.del-item');
    del_prod_item.forEach(item => {
        item.addEventListener('click', async (e) => await del_item_cart(e))
    })
}


const update_count_prod = (e) => {
    let product_count = e.target.value;
    let product_id = e.target.parentNode.parentNode.querySelector('.id').getAttribute('id-set');
    let request = '/load/api/cart/update/count';
    let request_body = JSON.stringify({
        product_id: parseInt(product_id),
        product_count: parseInt(product_count)
    });
    
    axios.put(host + request, request_body, config)
        .then(res => update_size_cart(res.data.cart_size));
}

const del_item_cart = async (e) => {
    if (!confirm('Xóa bỏ ?')) return;

    let product_id = e.target.parentNode.parentNode.querySelector('.id').getAttribute('id-set');
    let request = `/load/api/cart/del/${product_id}`;
    let result = null;
    await axios.delete(host + request)
        .then(res => result = res)
        .catch(ex => result = ex);

    console.log(result);    
    if (result !== null && result.data != null) {
        if (result.data.error != null || result.data.status === false) {
            alert(result.data.result);
            update_size_cart(result.data.cart_size);
            return;
        }

        if (result.data.status === true) {
            let prod_item = e.target.parentNode.parentNode.parentNode;
            let parent_prod_item = prod_item.parentNode;
            parent_prod_item.removeChild(prod_item);
            update_size_cart(result.data.cart_size);
            update_total_countall();
        }
    }

    let cart_container = document.querySelector('#cart-pay');
    if (cart_container.childElementCount == 0) window.location.href = host + '/cart';
}

const update_size_cart = (size) => {
    const ic_size = document.querySelector('.cart .num');
    ic_size.innerHTML = size;
}

const btn_ac_pay = document.querySelector('.btn-buy button[name="ac-pay"]');
if (btn_ac_pay !== null) {

    update_count_prod_child(false);

    let cart_container = document.querySelector('#cart-pay');
    let prod = cart_container.querySelectorAll('.item');
    prod.forEach(item => {
        let del_el = item.querySelector('.del-item');
        del_el.addEventListener('click', (e) => {
            if (!confirm('Xóa bỏ ?')) return;

            cart_container.removeChild(item);
        })
    })

    btn_ac_pay.addEventListener('click', async (e) => {
        prod = document.querySelectorAll('#cart-pay .item');
        if (prod == null || prod.length < 1) {
            alert('Đặt hàng không thành công !');
            window.location.href = host + '/cart';
            return;
        }

        const required_flex = document.querySelectorAll('.required-flex');

        let len = required_flex.length;
        for (let i = 0; i < len; i++) {
            let input = required_flex[i].parentNode.querySelector('input');
            let select = required_flex[i].parentNode.querySelector('select');
            if (input !== null && input.value === ''
                ||
                select != null && select.value === '#') {

                let res_mess = required_flex[i].innerText.split(':')[0] + ' là bắt buộc !';
                alert(res_mess);
                return;
            }
        }

        let first_name = document.querySelector('input[name="first-name"]').value;
        let last_name = document.querySelector('input[name="last-name"]').value;
        let phone = document.querySelector('input[name=phone]').value;
        let gender = document.querySelector('select[name=gender]').value;
        let province = document.querySelector('select[class=provinces]').value;
        let district = document.querySelector('select[class=districts]').value;
        let ward = document.querySelector('select[class=wards]').value;
        let address = document.querySelector('input[name="home-number"]').value;

        let request_body = {
            bill_infor: {
                first_name: first_name,
                last_name: last_name,
                phone: phone,
                gender: gender,
                address: address,
                ward: ward,
                district: district,
                city: province
            },
            products_cart: []
        }


        prod.forEach(item => {
            request_body.products_cart.push({
                product_id: parseInt(item.querySelector('.id').getAttribute('id-set')),
                product_count: parseInt(item.querySelector('.counter input[type=number]').value)
            })
        })

        let result = null;
        let request = '/load/api/cart/checkout';
        await axios.post(host + request, JSON.stringify(request_body), config)
            .then(res => result = res)
            .catch(ex => result = ex);


        console.log(result);
        if (result != null && result.data != null) {
            let mess_box = mess_box_show(result.data.status, result.data.content);
            mess_box.appendTo($('body'));
            let body = document.querySelector('body');
            body.classList.add('ov-hd');
            const btn_ok_box = document.querySelector('.mess-box .btn-s button[class=ok]');
            btn_ok_box.addEventListener('click', (e) => {
                if (result.data.status) {
                    window.location.href = host + result.data.url;
                    return;
                }

                document.querySelector('body').removeChild(
                    e.target.parentNode.parentNode.parentNode
                );
                body.classList.remove('ov-hd');
            })
        }
    })
}


const mess_box_show = (status, content) => {
    // alert(status + "/" + content);
    let i =
        status === true
            ? '<ion-icon name="checkbox"></ion-icon>'
            : '<ion-icon name="warning"></ion-icon>';
    let done = status === true ? "st-ss" : "";
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
