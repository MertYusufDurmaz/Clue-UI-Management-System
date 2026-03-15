# Clue-UI-Management-System
Clue & UI Management System
Bu modül, oyun içindeki toplanabilir notları, ipuçlarını ve dökümanları yöneten, UI (Arayüz) ile entegre çalışan bir sistemdir.

Özellikler:

ClueManager: Sahnedeki veya envanterdeki ipucu objelerinin state'ini (aktif/pasif) yönetir.

ClueListUI: Toplanan ipuçlarını dinamik olarak listeler ve UI Grid sistemine Prefab olarak instantiate eder.

Save/Load Hazır: Sistem, dışarıdan herhangi bir Save Manager'ın kolayca verileri çekip (Get), geri yükleyebileceği (Load) ayrık metotlara sahiptir. Sistemler arası ters bağımlılık (tight coupling) yoktur.

UIPanelController: Evrensel Canvas yöneticisi ile haberleşerek ipucu menüsünün tuş atamalarıyla pürüzsüzce açılıp kapanmasını sağlar.
