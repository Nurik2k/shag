   M S B A M L   `   `   `  ?????  ;KIWI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KIWIKIWI  5   	       KIWI.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:KIWI     5   	     ? Title$  
MainWindow??5   	   $	??300??6   $	??450??6)   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??20 ?6   6*   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      $??20 ?6   6*    ? ColumnDefinitions 5   
   ?? 5      $??20 ?6   6,   ?? 5      6!   ?? 5      6!   ?? 5      $??20 ?6   6,   .+?5   
   ?? $??1??6   $??1??6    $??2??6-   $??24(?6A   $??Center=?6O   .??6m   !Добро пожаловать6   ?? 5   
   $??2??6   $??1??6   $??16(?6-   $??Center=?6;   $??Center=?6V   .??6s   Логин:6{   ?? 5   
   $??2??6   $??2??6"   $??Center=?63   $??Center=?6N   .+?5      ?? -   5         ??Name$ tbxLogin??5   1   $??24(?6   $	??150??6%   6E   ?? 5      -   5         ??Name$ lblLoginMessage??5      $??Italic$?6-   
???  ??$??12(?6Q   5      ?? 5    
   $??3??6   $??1??6   $??16(?6-   $??Center=?6;   $??Center=?6V   .??6s   Пароль:6|   G? 5!   
   -   5         G?Name$ tbxPassword??5!   ?   $??3??6   $??2??6#   $??24(?63   $??Center=?6A   $??Center=?6\   $	??150??6y   6?   ?? 5"   
   -   5         ??Name$ btnAuth??5"      $??2??6"   $??5??62   $	??150??6?   $??25??6K   .??6m   
Войти6t   5#      5$      