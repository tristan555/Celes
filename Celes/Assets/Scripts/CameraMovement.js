#pragma strict
#pragma implicit
#pragma downcast
 // e posto je ovo java ja sam naso nedje na netu ovaj program slicno je ko c# samo puno lijenije ali je spica uglavnom
var target : Transform;//ono u sta kamera bulji
var layermask : LayerMask;//ono sa cim se moze kamera sudarit
var distance = 5.0;//udaljenost od lopte
var damping : float = 6.0;//sama rijec kaze
var cameraJoystick : VirtualJoystick;//ovo nam je joystick za upravljanje kamerom
var xSpeed = 1.0;//brzina po x koordinati
var ySpeed = 1.0;//brzina po y koordinati
 
var yMinLimit = -10;// max brzina po x koordinati
var yMaxLimit = 75;// max brzina po x koordinati
 
// ovo ispod su sranja obicna vezana za rotaciju i kretanje eto samo da nam ko pomognu
private var x = 0.0;
private var y = 0.0;
 
var smoothTime = 0.3;

private var xSmooth = 0.0;
private var ySmooth = 0.0;
private var xVelocity = 0.0;
private var yVelocity = 0.0;
 
private var posSmooth = Vector3.zero;
private var posVelocity = Vector3.zero;
 
@script AddComponentMenu("Camera-Control/Mouse Orbit")//ovo je da imas posebnu opciju u komponentama da odaberes skriptu(mozes i obrisat i mene nervira)
 
function Start () {
    var angles = transform.eulerAngles;//hocemo uglove u ojlerovim vrijednostima
    
 
    // ovde lopta nece promijenit rotaciju kad se bude kamera vrtila
    if (GetComponent.<Rigidbody>())
        GetComponent.<Rigidbody>().freezeRotation = true;
}
function Update(){//eh ovde se nas VJ proslavlja(dajemo x i y koordinate kameri u odnosu na VJ)
if(target){
x -= cameraJoystick.InputDirection.x * xSpeed;
y += cameraJoystick.InputDirection.z * ySpeed;
}
}
 
function LateUpdate () {              
 
    if (target){//if lopta??? WTF (eh vidis kad stavis vako if(gameObject) on vraca true ako se ikako nalazi u toj sceni objekt)
       	
        xSmooth = Mathf.SmoothDamp(xSmooth, x, xVelocity, smoothTime);
        ySmooth = Mathf.SmoothDamp(ySmooth, y, yVelocity, smoothTime);
 
        ySmooth = ClampAngle(ySmooth, yMinLimit, yMaxLimit);
 
        var rotation = Quaternion.Euler(ySmooth, xSmooth, 0);
 
       //ovo iznad samo rotaciju nesto namjesta ni ja ne kontam sjeb je totalni,ispod isto tako
 
        posSmooth = target.position;
 
        transform.rotation = rotation;
        transform.position = rotation * Vector3(0.0, 0.0, -distance) + posSmooth;
    }
	
	//da ovog ispod koda nema kamera bi nam prolazila kroz zidove,ostatak do kraja se igra sa rotacijom eventualno nista vrijedno 
	//pomena u ovom slucaju ko ce se i sa tim jos peglat
    var hit : RaycastHit;
    if(Physics.Linecast(target.position, transform.position,hit,layermask)){
        var tempDistance = Vector3.Distance(target.position,hit.point);
        position = rotation * Vector3(0.0, 0.0, -tempDistance) + target.position;
        transform.position = position;
    }
    if(y > yMaxLimit)
		y = yMaxLimit;
	
	if(y < yMinLimit)
		y = yMinLimit;
}
 
static function ClampAngle (angle : float, min : float, max : float) {
    if (angle < -360)
        angle += 360;
    if (angle > 360)
        angle -= 360;
    return Mathf.Clamp (angle, min, max);
}
 