#pragma strict

var Dossun : Transform;

function Update () {
    if(Time.frameCount % 500 == 0) {

      Instantiate(Dossun, Vector3(Random.Range(-10,10),50,Random.Range(-10,10)),transform.rotation);
}	
}
