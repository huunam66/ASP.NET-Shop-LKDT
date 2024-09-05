const main = () => {
  $(document).ready(function () {
    const fill_click = () => {
      const r = $(".row-t-ops");
      const it = r.find(".item");
      it.each(function () {
        const o = $(this).find("ol");
        $(this).on("click", function () {
          if (o.hasClass("dnone")) {
            o.removeClass("dnone");
          } else {
            o.addClass("dnone");
          }
        });
      });
    };
    fill_click();
  });
};
main();
