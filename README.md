## GrafikaKomputerowa
# Eksplorator zbioru Mandelbrot'a w programie Unity
### Michał Kornaus - 195IC_A

#### Projekt ten jest działającym eksploratorem zbioru Mandelbrot'a - można przemieszczać się po nim przyciskami WSAD, wgłębiać się przyciskiem SHIFT oraz oddalać się przyciskiem spacji.

##### Widok projektu odpalonego w Unity - korzystam jedynie z podstawowego elementu Canvas(płótna do elementów 2D) oraz wewnątrz z elementu RawImage, na którym mogę renderować fraktale dzięki shaderowi.
![unity0](/Screens/Unity0.PNG)
##### Wygląd całego zbioru Mandelbrot'a
![unity00](/Screens/Unity00.PNG)
##### Podczas odpalonego programu możemy poruszać się po zbiorze dość płynnie(zależnie od ustawionej ilości iteracji w shaderze, który generuje obraz)
![unity1](/Screens/Unity1.PNG)
##### Możemy zaznaczyć element RawImage na którym renderują się fraktale aby podejrzeć detale i parametry.  W skrypcie Explorer na prawo od obrazu widzimy parę zmiennych o nazwach Pos, Scale oraz Max Iter.
##### Najważnieszą z tych zmiennych jest Scale ponieważ od niej zależy jak głęboko jesteśmy w zbiorze. Pozycję i skalę przekazuje do shadera którego widać pod skryptem. Znajduje się tam równie ważna zmienna Iterations, która określa dokładność wyświetlania fraktala.
![unity2](/Screens/Unity2.PNG)
##### Po zmianie wartości Iterations z 1500 na 250 widać wielką różnicę lecz nie ważne jaka wartość, możemy przy takiej wartości eksplorować Mandelbrot'a aż do osiągnięcia limitu wartości float zmiennej Scale(zbliżenia)
![unity3](/Screens/Unity3.PNG)
##### Pokazanie różnych konfiguracji i wgłębień:
![unity4](/Screens/Unity4.PNG)
![unity5](/Screens/Unity5.PNG)
##### Po przekroczeniu pewnej wartości Scale, shader nie może już głębiej renderować fraktala, więc dochodzimy do widocznych pikseli na obrazie.
![unity6](/Screens/Unity6.PNG)
##### Można z tego niskiego poziomu przetestować parametr Iterations aby lepiej zaobserwować jak działa. Dla wartości 5500:
![unity7a](/Screens/Unity7a.PNG)
##### Dla wartości 9000
![unity7b](/Screens/Unity7b.PNG)
##### Dla wartości 1500
![unity7c](/Screens/Unity7c.PNG)
##### Kod shadera pokazany w Visual Studio. Jak widać trzeba dużo kalkulacji aby obliczyć obraz zbioru Mandelbrot'a. Zmienna _Area jest tworzona z koordynatów według których się poruszamy. 
![Kod1](/Screens/Kod1.PNG)
