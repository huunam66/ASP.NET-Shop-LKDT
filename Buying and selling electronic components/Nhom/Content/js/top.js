const top_js = () => {
  $(document).ready(function () {
    const hov_head = () => {
      const h = $("header");
      const ih = h.find(".item");
      ih.each(function () {
        const oe = $(this).find(".ol-el");
        if (oe.html() != undefined) {
          $(this).on("mouseenter", function () {
            oe.removeClass("dnone");
          });
          $(this).on("mouseleave", function () {
            oe.addClass("dnone");
          });
        }
      });
    };
    hov_head();
  });
};
top_js();
