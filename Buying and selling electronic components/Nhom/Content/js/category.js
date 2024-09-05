const category = () => {
  $(document).ready(function () {
    // const more_show = () => {
    //   const c = $(".category .list-item .item");
    //   c.each(function () {
    //     const p = $(this).find(".more");
    //     const o = $(this).find("ol");
    //     $(this).on("mouseenter", function () {
    //       p.removeClass("dnone");
    //     });
    //     p.on("click", function () {
    //       const i = $(this).find("i");
    //       if (i.hasClass("ph-plus")) {
    //         i.toggleClass("ph-plus ph-minus");
    //         o.removeClass("dnone");
    //       } else {
    //         i.toggleClass("ph-minus ph-plus");
    //         o.addClass("dnone");
    //       }
    //     });
    //     $(this).on("mouseleave", function () {
    //       p.addClass("dnone");
    //     });
    //   });
    // };
    // more_show();

    const category_show = () => {
      const cg = $(".category");
      const cme = cg.find(".cme");
      cme.on("click", function () {
        const move_r_s = cg.hasClass("move-r-ctg");
        const i = $(this).find("i");
        if (!move_r_s) {
            i.toggleClass("ph-list ph-x");
            cg.removeClass("move-l-ctg");
          cg.addClass("move-r-ctg");
        } else {
          i.toggleClass("ph-x ph-list");
            cg.removeClass("move-r-ctg");
            cg.addClass("move-l-ctg");
        }
      });
    };
    category_show();
  });
};
category();
