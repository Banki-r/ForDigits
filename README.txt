
# For Digits

Az OKJ tanulmányaim végén mint szakdolgozat, készítettem el ezt a projektet.
Egy egyszemélyes, belsőnézetes, puzzle játékról van szó amit Unityben és C#-al készítettem el, kicsit több mint félév alatt.

Csatolva van egy osztály diagram is a projekthez amiben az alapvető osztályok hierarchiáját lehet megtekinteni.

Direkt könnyen skálázhatóra terveztem, amit sajnos végül időhiányában csak részben tudtam kihasználni.
A legnehezebb rész az InterakcioRendszer kiépítése volt, amit semmiképpen nem akartam spaghetti kóddal megoldani,
oda találtam ki a jelenlegi rendszert. Akármilyen interakciót hozzna létre a fejlesztő, elég egy előredefiniált
InterakcioAlap nevezetű osztályból leszármaztatnia ami minden szükséges funkciót megad neki.
Ezek átláthatósága érdekében minden interakció típus külön-külön osztályokban (és ezáltal fájlokban) vannak eltárolva.

A grafikai része a játéknak hagy kivetni valót maga után, de nem is ezen volt a hangsúly.
