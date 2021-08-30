<?php

//DB接続関数（PDO）
function db_con(){
  $dbname='sc_project';
  try {$pdo = new PDO('mysql:dbname=sc_project;host=mysql;charset=utf8mb4','ユーザー名','パスワード',
        [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,]);
      } catch (PDOException $e) {
    exit('DbConnectError:'.$e->getMessage());
  }
  return $pdo;
}



$stmt = $pdo->prepare("SELECT "カラム名" from "テーブル名" where "時刻保持カラム" > current_timestamp + interval -5 SECOND"); //現在時刻から -5秒 のデータのみ取得
$stmt->execute();
$res = $stmt->fetchAll();


echo count ($res);


