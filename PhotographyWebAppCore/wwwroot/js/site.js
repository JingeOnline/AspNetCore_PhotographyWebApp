// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//调用bricklayer脚本，来实现瀑布流
//var bricklayer = new Bricklayer(document.querySelector('.bricklayer'))

//按照官方的教程布局会出问题，所以把他放到页面加载完成之后执行，解决该问题。
window.onload = (event) => {
    var bricklayer = new Bricklayer(document.querySelector('.bricklayer'))
};