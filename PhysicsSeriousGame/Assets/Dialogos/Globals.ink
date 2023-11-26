VAR tutoSillasOrdenadas = ""
VAR ForemanTutoFinishedDoorOpen = false
VAR EllieExp1AlreadyTalked = false
VAR BaoExp2AlreadyTalked = false
VAR KAOExp3AlreadyTalked = false
VAR ForemanExp4AlreadyTalked = false

EXTERNAL ActivarEventoFinalForeman()
EXTERNAL ActivarEventoKAO()
EXTERNAL EnableBoxes()
EXTERNAL EnableChairs()
EXTERNAL AbrirPuertaTuto()
EXTERNAL AnimarCientifico(nombreAnimacion)
EXTERNAL FadeInPrologo()
EXTERNAL AnimarCRAB(nombreAnimacion)
EXTERNAL ActivateIntroEvent3D()