/*
 Template Name: Zoter - Bootstrap 4 Admin Dashboard
 Author: Mannatthemes
 Website: www.mannatthemes.com
 File: Datatable js
 */

$(document).ready(function() {
    $('#datatable').DataTable();
    $('#datatable2').DataTable();
    $('#datatable3').DataTable();
    $('#datatable231').DataTable();
    $('#datatableNotifier').DataTable();
    $('#datatableAffected').DataTable();
    $('#datatableDepartment').DataTable();
    $('#datatableController').DataTable();
    $('#datatableUnSafeBehaviour').DataTable();
    $('#datatableUnSafeCondition').DataTable();

 
   

    //Buttons examples
    var table = $('#datatable-buttons').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table.buttons().container().appendTo('#datatable-buttons_wrapper .col-md-6:eq(0)');

    var table2 = $('#datatable-buttons2').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table2.buttons().container().appendTo('#datatable-buttons2_wrapper .col-md-6:eq(0)');

    var table3 = $('#datatable-buttons3').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    }); 
    table3.buttons().container().appendTo('#datatable-buttons3_wrapper .col-md-6:eq(0)');

    var table4 = $('#datatable-buttons4').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table4.buttons().container().appendTo('#datatable-buttons4_wrapper .col-md-6:eq(0)');

    var table5 = $('#datatable-buttons5').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table5.buttons().container().appendTo('#datatable-buttons5_wrapper .col-md-6:eq(0)');

    var table6 = $('#datatable-buttons6').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table6.buttons().container().appendTo('#datatable-buttons6_wrapper .col-md-6:eq(0)');

    var table7 = $('#datatable-buttons7').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table7.buttons().container().appendTo('#datatable-buttons7_wrapper .col-md-6:eq(0)');
    
    var table8 = $('#datatable-buttons8').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table8.buttons().container().appendTo('#datatable-buttons8_wrapper .col-md-6:eq(0)');
    
    var table9 = $('#datatable-buttons9').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table9.buttons().container().appendTo('#datatable-buttons9_wrapper .col-md-6:eq(0)');
    
    var table10 = $('#datatable-buttons10').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table10.buttons().container().appendTo('#datatable-buttons10_wrapper .col-md-6:eq(0)');

    var table11 = $('#datatable-buttons11').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table11.buttons().container().appendTo('#datatable-buttons11_wrapper .col-md-6:eq(0)');

    var table12 = $('#datatable-buttons12').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table12.buttons().container().appendTo('#datatable-buttons12_wrapper .col-md-6:eq(0)');
    
    var table13 = $('#datatable-buttons13').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table13.buttons().container().appendTo('#datatable-buttons13_wrapper .col-md-6:eq(0)');

    var table14 = $('#datatable-buttons14').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table14.buttons().container().appendTo('#datatable-buttons14_wrapper .col-md-6:eq(0)');

    var table15 = $('#datatable-buttons15').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table15.buttons().container().appendTo('#datatable-buttons15_wrapper .col-md-6:eq(0)');

});