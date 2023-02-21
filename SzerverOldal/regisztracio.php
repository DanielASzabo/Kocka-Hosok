<?php

require_once('kapcsolat.php');
if (!empty($_POST['nev']) && !empty($_POST['jsz']) && !empty($_POST['email'])) {
    $nev = $_POST['nev'];
    $jsz1 = $_POST['jsz'];
    $jsz = md5($jsz1);
    $email = $_POST['email'];
    $kapcsolattom = new Kapcsolat();
    $oszlopNevek = array('felhnev', 'email', 'jelszo');
    $adatok = array($nev, $email, $jsz);
    $vanbenne = $kapcsolattom->keresesOszlopban("felhasznalok", "email", $email);
    if ($vanbenne->num_rows == 0) {
        $kapcsolattom->adatBeszuras("felhasznalok", $oszlopNevek, $adatok);
    } else {
        echo 'van már felhasználó';
    }
    $kapcsolattom->lezar();

    //}
} else {
    echo 'Töltse ki az összes mezőt!';
}
?>
