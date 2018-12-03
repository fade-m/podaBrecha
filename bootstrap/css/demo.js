$(document).ready(function() {
    $('#tabla1').fixedHeaderTable({ footer: true, cloneHeadToFoot: true, altClass: 'odd', autoShow: false });
    $('#tabla1').fixedHeaderTable('show', 1000);
});
