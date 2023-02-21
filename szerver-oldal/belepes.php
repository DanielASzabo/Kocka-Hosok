<?php

if (!empty($_POST['email']) && !empty($_POST['jsz'])) {
    $email = $_POST['email'];
    $jsztiszta = $_POST['jsz'];
    $jsz = md5($jsztiszta);
    require_once('kapcsolat.php');
    $kapcsolattom = new Kapcsolat();
    $sorok = array("email", "jelszo");
    $miket = array($email, $jsz);
    $adat = $kapcsolattom->keresesAdatokTablaban("felhasznalok", $sorok, $miket);
    if ($adat->num_rows > 0) {
        while ($sor = $adat->fetch_assoc()) {
            echo $sor["felhnev"];
        }
        
    } else {
        echo -1;
    }
    $kapcsolattom->lezar();
} else {
    echo 'Töltse ki az összes mezőt!';
}
?>
