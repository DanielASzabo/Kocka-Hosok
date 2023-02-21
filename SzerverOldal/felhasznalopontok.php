<?php

if (!empty($_POST['email'])) {
    $email = $_POST['email'];
    require_once('kapcsolat.php');
    $kapcsolattom = new Kapcsolat();
    $sorok = array("email");
    $miket = array($email);
    $adat = $kapcsolattom->keresesAdatokTablaban("felhasznalok", $sorok, $miket);
    if ($adat->num_rows > 0) {
        $pontok = $kapcsolattom->keresesAdatokTablaban("ranglista", array("email"), array($email));
        $i = 0;
        $jsonObjTomb = array();
        while ($sor = $pontok->fetch_assoc()) {
            
            $palyaadatok = $kapcsolattom->keresesOszlopban("palyak", "palyaid", $sor["palyaid"]);
            while ($sorbel = $palyaadatok->fetch_assoc()) {
                $jsonObj = new stdClass();
                $jsonObj->vilag = $sorbel["vilag"];
                $jsonObj->palya = $sorbel["palya"];
                $jsonObj->pontok = $sor["pontok"];
                array_push($jsonObjTomb,$jsonObj);
            }
        }
        echo json_encode($jsonObjTomb);
    } else {
        echo '';
    }
    $kapcsolattom->lezar();
} else {
    echo 'Be kell jelentkezni a pontok megtekintéséhez';
}
