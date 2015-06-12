using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour
{
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        if (!photonView.isMine)
        {
            //Debug.Log("Smooth update");
            //Debug.Log(transform.position);// - this.correctPlayerPos);
            //Debug.Log(this.correctPlayerPos);
            //Debug.Log(Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
            // Network player, receive data
            Vector3 local = (Vector3)stream.ReceiveNext();
            Debug.Log(local);
            Debug.Log(this.correctPlayerPos);
            this.correctPlayerPos = local;//(Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
            Debug.Log(">>>");
            //Debug.Log(this.correctPlayerPos);
           //Debug.Log(transform.position);
        }
    }
}