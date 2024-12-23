<?php

session_start();

?>


<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Kapcsolat</title>
    <link rel="stylesheet" type="text/css" href="css/contact.css">
    <link rel="stylesheet" type="text/css" href="css/print.css">
    <link rel="shortcut icon" href="assets/Logo.png" type="image/x-icon">
</head>

<body>
<header id="navbar"></header>
<hr>
<div class="container">
    <h1 id="content">Mondd el a véleményed</h1>
    <p>Kérlek jelezz, ha van bármi ötleted, vagy észrevételed. Nagyon szépen köszönjük.</p>
    <hr>
    <div class="form">
        <form action="backend/send.php" method="post">

            <div class="input">
                <label for="email" class="input-label">
                    <input id="email" name="email" class="field" type="email" placeholder=" " maxlength="25">
                    <span class="label">Email</span>
                </label>
            </div>

            <div class="input">
                <label for="full-name" class="input-label">
                    <input class="field" name="full-name" id="full-name" type="text" placeholder=" " maxlength="45">
                    <span class="label">Teljes Név</span>
                </label>
            </div>

            <div class="input radio">
                <p>Nem: </p>
                <label for="male" class="radio-label">
                    Férfi
                    <input class="radio-field" name="gender" value="male" type="radio" id="male">
                </label>
                <span></span>
                <label for="female" class="radio-label">
                    Nő
                    <input class="radio-field" name="gender" value="female" type="radio" id="female">
                </label>
            </div>
            <div class="input radio">
                <label for="newsletter" class="radio-label">
                    Szeretnék hírleveleket
                    <input class="radio-field" name="newsletter" type="checkbox" id="newsletter">
                </label>
            </div>

            <div class="input">
                <label for="comment" class="input-label">
                    <textarea class="field" name="comment" id="comment" cols="30" rows="10" required
                              placeholder=" " maxlength="2000"></textarea>
                    <span class="label">Megjegyzés</span>
                </label>
            </div>
            <div class="button-group">
                <button>Send</button>
                <button type="reset">Reset</button>
            </div>
        </form>
        <section>
            <h2>Mit adunk cserébe:</h2>
            <p>Az oldalon található űrlap segítségével küldhetsz üzenetet a vezetőknek, hogy még gyorsabban fejlődjön a
                foglalkozások menete és minősége. Nyugodtan írd meg, ha valami nem tetszik, vagy nem jól sikerült.
                Azt is szeretnénk hallani, hiszen ha nem mondod el, nem tudunk javítani rajta.</p>
            <p>Az észrevételed, lehet bármilyen új ötlet, vagy aktivitás, ami még nincs bevezetve a foglalkozásokra.
                Ha egy ötleted végül bevezetésre kerül, kaphatsz egy "Innovator" jelvényt amit a profilodon lesz majd
                látható.</p>
            <p>Ha bármi észrevételed van a weblap működésével, vagy szeretnél mást is látni az oldalon, kérlek ezt
                se tartsd magadban. Bármi nemű hozzájárulást nagyon szépen köszönünk.</p>
        </section>
    </div>
    <div id="toast-container"></div>
</div>
<footer id="footer" class="footer notprint"></footer>
<script src="js/jquery.js"></script>
<script src="js/functions.js"></script>
<script src="js/main.js"></script>

<?php
if (isset($_SESSION['message']) && !$_SESSION['shown']) {
    $_SESSION['shown'] = true;
    ?>
    <script>b5toast.show("success", "Siker", "Üzenet elküldve!");</script>
<?php } ?>

</body>

</html>
