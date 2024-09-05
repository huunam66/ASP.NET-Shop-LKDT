

const avt = document.querySelector('.avt-s .pic');
const inp_file = document.querySelector('.avt-s .pic input[type=file]');
avt.addEventListener('click', (e) => inp_file.click());
inp_file.addEventListener('change', (e) => {
    let fReader = new FileReader();
    fReader.readAsDataURL(e.target.files[0]);
    fReader.onloadend = (ev) => {
        avt.querySelector('.avt').setAttribute('src', ev.target.result);
    }
})

const btn_edit = document.querySelector('.opt-ev button');
btn_edit.addEventListener('click', (e) => {
    const required_flex = document.querySelectorAll('.required-flex');
    for (let i = 0; i < required_flex.length; i++) {
        let input = required_flex[i].parentNode.querySelector('input');
        let select = required_flex[i].parentNode.querySelector('select');
        if (input !== null && input.value === '' || select !== null && select.value === '#') {
            let mess = required_flex[i].innerText.split(':')[0] + ' là bắt buộc !';
            alert(mess);
            return;
        }
    }

    e.target.type = 'submit';
})