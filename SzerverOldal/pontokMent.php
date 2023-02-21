<?php

if (!empty($_POST['email']) && !empty($_POST['vilag']) && !empty($_POST['palya']) && !empty($_POST['pontok'])) {
    $email = $_POST['email'];
    $vilag = $_POST['vilag'];
    $palya = $_POST['palya'];
    $pont = $_POST['pontok'];
    require_once('kapcsolat.php');
    $kapcsolattom = new Kapcsolat();
    $sorok = array("vilag", "palya");
    $miket = array($vilag, $palya);
    $tablanev = "ranglista";
    $adat = $kapcsolattom->keresesAdatokTablaban("palyak", $sorok, $miket);
    if ($adat->num_rows > 0) {
        while ($sor = $adat->fetch_assoc()) {
            
            $palyaid = $sor["palyaid"];
            $kulcsnevek = array("email", "palyaid");
            $kulcsertekek = array($email, $palyaid);
            $pontok = $kapcsolattom->keresesAdatokTablaban($tablanev, $kulcsnevek, $kulcsertekek);
            
            if ($pontok->num_rows > 0) {
                while ($pontadat = $pontok->fetch_assoc()) {
                    if ($pontadat["pontok"] < $pont) {
                        $kapcsolattom->adatModositasOszetet($tablanev, $kulcsnevek, $kulcsertekek, "pontok", $pont);
                        echo 'nagyobb a pont updatelve';
                    }
                }
            } else {
                $adatok = array($email, $sor["palyaid"], $pont);
                $oszlopNevek = array("email", "palyaid", "pontok");
                $kapcsolattom->adatBeszuras($tablanev, $oszlopNevek, $adatok);
                
            }
        }
    } else {
        echo 'nincs ijen palya a tablaban';
    }
    $kapcsolattom->lezar();
} else {
    echo 'Be kell jelentkezni a pontok megtekintéséhez';
}
