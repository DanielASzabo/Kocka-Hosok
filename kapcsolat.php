<?php

class Kapcsolat {

//    private $hoszt = "localhost";
//    private $fnev = "root";
//    private $jelszo = "";
//    private $adatbNev = "kockahosok";
    
    
    private $hoszt = "tanulo1.szf1a.oktatas.szamalk-szalezi.hu";
    private $fnev = "c1_tanulo1szf1a";
    private $jelszo = "_tanulo1szf1a";
    private $adatbNev = "c1ABtanulo1szf1a";
    private $kapcsolat;

    function __construct() {
        $this->kapcsolat = new mysqli($this->hoszt, $this->fnev, $this->jelszo, $this->adatbNev) or die("Hiba a kapcsolat létrehozásakor!");
        $this->kapcsolat->query("SET NAMES UTF8");
        $this->kapcsolat->query("set character set UTF8");
        $this->kapcsolat->query("set collation_connection='utf8_hungary_ci'");
    }

    
    function adatBeszuras($tablanev, $oszlopNevek, $adatok) {
        $beszurasLek = "INSERT INTO " . $tablanev . " (";
        $i = 0;
        foreach ($oszlopNevek as $value) {
            if ($i < sizeof($oszlopNevek) - 1) {
                $beszurasLek .= $value . ", ";
            } else {
                $beszurasLek .= $value;
            }
            $i += 1;
        }
        $beszurasLek .= ") VALUES (";
        $i = 0;
        foreach ($adatok as $value) {
            if ($i < sizeof($adatok) - 1) {
                $beszurasLek .= "'" . $value . "', ";
            } else {
                $beszurasLek .= "'" . $value . "');";
            }
            $i += 1;
        }
        echo $beszurasLek;
        $lekerdezes = $this->kapcsolat->query($beszurasLek);
        if ($lekerdezes) {
            echo 'sikeres beszurás ';
        } else {
            echo 'sikertelen beszurás ';
        }
    }

    function keresesOszlopban($tablanev, $oszlopNev, $mit) {
        $keresLek = "SELECT * FROM " . $tablanev . " WHERE " . $oszlopNev . " = '" . $mit . "'";
        $lekerdezes = $this->kapcsolat->query($keresLek);
        return $lekerdezes;
    }

    function keresesTablaban($tablanev, $mit) {
        $keresesLek = "SELECT * FROM " . $tablanev . " WHERE ";
        $sornevekLek = "SHOW COLUMNS FROM " . $tablanev;
        $tablaadatok = $this->kapcsolat->query($sornevekLek);
        $i = 0;
        while ($sor = $tablaadatok->fetch_row()) {
            if ($i < $tablaadatok->num_rows - 1) {
                $keresesLek .= $sor[0] . " = '" . $mit . "' OR ";
            } else {
                $keresesLek .= $sor[0] . " = '" . $mit . "'";
            }
            $i += 1;
        }
        $lekerdezes = $this->kapcsolat->query($keresesLek);
        if ($lekerdezes) {
            if($lekerdezes->num_rows >0){
            echo 'van elem a táblában ';
            } else {
                echo 'nincs elem a táblában ';
            }
        } else {
            echo 'hibás lekérdezés ';
        }
    }
    
    function keresesAdatokTablaban($tablanev,$sorok, $miket) {
        $keresesLek = "SELECT * FROM " . $tablanev . " WHERE ";
        $i = 0;
        for($i = 0; $i<sizeof($sorok); $i++){
            if ($i < sizeof($sorok) - 1) {
                $keresesLek .= $sorok[$i] . " = '" . $miket[$i] . "' AND ";
            } else {
                $keresesLek .= $sorok[$i] . " = '" . $miket[$i] . "'";
            }
        }
        return $lekerdezes = $this->kapcsolat->query($keresesLek);
            
        
    }

    function adatTorles($tablanev, $kulcsnev, $kulcsertek) {
        $torlesLek = "DELETE FROM " . $tablanev . " WHERE " . $kulcsnev . " = '" . $kulcsertek . "'";
        $lekerdezes = $this->kapcsolat->query($torlesLek);
        if ($lekerdezes) {
            echo 'sikeres törlés ';
        } else {
            echo 'sikertelen törlés ';
        }
    }

    function adatModositas($tablanev, $kulcsnev, $kulcsertek, $oszlopnev, $mivel) {
        $frissitesLek = "UPDATE " . $tablanev . " SET " . $oszlopnev . " = '" . $mivel . "'" . " WHERE " . $kulcsnev . " = '" . $kulcsertek . "'";
        $lekerdezes = $this->kapcsolat->query($frissitesLek);
        if ($lekerdezes) {
            echo 'sikeres modositás ';
        } else {
            echo 'sikertelen modositás ';
        }
    }

    function adatModositasOszetet($tablanev, $kulcsnev, $kulcsertek, $oszlopnev, $mivel) {
        $frissitesLek = "UPDATE " . $tablanev . " SET " . $oszlopnev . " = '" . $mivel . "'" . " WHERE ";
        for ($index = 0; $index < count($kulcsnev); $index++) {
            if($index< sizeof($kulcsnev)-1){
                $frissitesLek .= $kulcsnev[$index] . " = '" . $kulcsertek[$index] . "' AND ";
            }else{
                $frissitesLek .= $kulcsnev[$index] . " = '" . $kulcsertek[$index] . "'";
            }
            
        }
        echo $frissitesLek;
        $lekerdezes = $this->kapcsolat->query($frissitesLek);
        if ($lekerdezes) {
            echo 'sikeres modositás ';
        } else {
            echo 'sikertelen modositás ';
        }
    }
    
    
    function lekerdezMind($tabla) {
        $sql = "SELECT * FROM " . $tabla;
        $lekerdezes = $this->kapcsolat->query($sql);
        return $lekerdezes;
    }

    public function lezar() {
        $this->kapcsolat->close();
    }

}
?>

