const log_regis = () => {
  $(document).ready(function () {
    const lb_mv = () => {
      const f = $("form");
      const l = f.find("label");
      const ip = f.find("input");
      for (let i = 0; i < l.length; i++) {
        $(ip[i]).on("focus", function () {
          $(l[i]).addClass("m-lb-t");
        });
        $(ip[i]).on("focusout", function () {
          const ip_i = $(ip[i]);
          if (ip_i.val() == "") {
            $(l[i]).removeClass("m-lb-t");
          }
        });
        $(l[i]).on("click", function () {
          $(ip[i]).focus();
        });

        const ic = $(l[i]).siblings("i");
        ic.on("click", function () {
          const cl = ic.hasClass("ph-eye");
          if (cl) {
            $(this).toggleClass("ph-eye ph-eye-slash");
            $(ip[i]).attr({ type: "text" });
          } else {
            $(this).toggleClass("ph-eye-slash ph-eye");
            $(ip[i]).attr({ type: "password" });
          }
        });
      }
    };
    lb_mv();
  });
};
log_regis();
