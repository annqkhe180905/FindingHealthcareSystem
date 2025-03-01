// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//active nav-link at current page
const currentPage = window.location.pathname;
if (currentPage === "/") {
    document.getElementById('home-link').classList.add('active');
} else if (currentPage === "/aboutus.html") {
    document.getElementById('search-link').classList.add('active');
} else if (currentPage === "/contact.html") {
    document.getElementById('appointment-link').classList.add('active');
} else if (currentPage === "/blog.html") {
    document.getElementById('blog-link').classList.add('active');
}



