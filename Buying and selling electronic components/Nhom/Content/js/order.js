const select_all = document.querySelectorAll('form select');

select_all.forEach(item => {
    item.addEventListener('change', (e) => {
        e.target.parentNode.parentNode.querySelector('button[type=submit]').click();
    })
})


const host = 'https://localhost:44340';
const config = {
    "headers": {
        "content-type": "application/json"
    }
}


const btn_canc_bill = document.querySelector('.canc-bil');
if (btn_canc_bill != null) {
    btn_canc_bill.addEventListener('click', async (e) => {

        let set = e.target.getAttribute('set');
        if (set === 'cancel' || set === 'duyet') {
            if (set === 'cancel')
                if (!confirm("Xác nhận hủy đơn hàng ?")) return;
            if (set === 'duyet')
                if (!confirm("Xác nhận duyệt đơn hàng ?")) return;

            let bill_id = e.target.getAttribute('id-set');

            let request = set === 'cancel' ? `/load/api/order/cancel` : `/load/api/order/duyet`;
            let request_body = JSON.stringify({
                bill_id: parseInt(bill_id)
            })

            let result = null;
            await axios.put(host + request, request_body, config)
                .then(res => result = res)
                .catch(ex => result = ex);


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
            else console.log(result);
        }

        if (set === 'again') {
            if (!confirm("Xác nhận đặt hàng lại ?")) return;

            let tr = document.querySelectorAll('tbody tr');
            let request = '/load/api/pay';
            let request_body = [];
            tr.forEach(item => {
                request_body.push({
                    product_id: parseInt(item.querySelector('.name a').getAttribute('id-set')),
                    product_count: parseInt(item.querySelector('.counter').innerText)
                });
            });

            let result = null;
            await axios.post(host + request, request_body, config)
                .then(res => result = res)
                .catch(ex => result = ex);

            if (result != null && result.data != null) {
                window.location.href = host + result.data.url;
            }
            else console.log(result);
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