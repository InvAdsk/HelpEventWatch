# HelpEventWatch
Warum ändert Inventor Dateien ...

In Inventor / Vault Umgebungen kommt es vor, das Freigegeben Dateien und nicht ausgecheckte Dateien im Vault Explorer innerhalb des Inventor einen "*" bekommen.

Dies bringt meist einen erhelbliche Arbeitsaufwand, bis das alles wieder im Tresor ist.
Was und warum die Datei von Inventor geändert wurde, ist nicht nachvollziehbar.

----

Nach dem Start der EXE koppelt sich das Programm an alle Events, die bei Änderungen an Dateien vom Inventor ausgelöst werden.
Damit wird erkennbar, ob und welche z.b. grafische / geometrische Aktion die Ursache ist, oder eine Property Änderung.

Ist die genaue Ursache bekannt, ist sie meist zu elemnieren und die Probleme beim Einchecken von Dateien sind behoben
