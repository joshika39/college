$(function () {

  if (!getCookie('font-size')) {
    setCookie('font-size', getProperty(':root', '--font-value'), 90);
  } else {
    setProperty(':root', '--font-value', getCookie('font-size'));
  }

  changeContrast(getCookie('high-contrast') == 'true');

  loadHtml('layout/nav.html', 'navbar', createNavbar);
  loadHtml('layout/footer.html', 'footer', () => { });
});

