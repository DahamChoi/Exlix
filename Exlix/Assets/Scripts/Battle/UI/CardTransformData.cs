using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTransformData : MonoBehaviour {
    public string UUID { get; set; }
    public float ScaleSpeed { get; set; }
    public float TargetAngle { get; set; }
    public Vector3 TargetPosition { get; set; }
    public int SortOrder { get; set; }
    public float OffsetAngle { get; set; }
    public float TargetScale { get; set; }
    public float MoveSpeed { get; set; }
    public float LastOnTime { get; set; }
    public float CurAngle { get; set; }
    public float NonInteractBegin { get; set; }
    public float TotalDistance { get; set; }
    public float OriginHighY { get; set; }
    public bool IsPlaying { get; set; }
    public bool IsDropping { get; set; }
    public float DropDisplayTime { get; set; }
    public GameObject TargetPlayer { get; set; }

    //public CardInfo Info { get; set; }

    public CardTransformData() {
        this.ScaleSpeed = 1.0f;
        this.TargetAngle = 0.0f;
        this.TargetPosition = Vector3.zero;
        this.SortOrder = 0;
        this.OffsetAngle = 0.0f;
        this.TargetScale = 0.7f;
        this.MoveSpeed = 1.0f;
        this.LastOnTime = 0.0f;
        this.CurAngle = 0.0f;
        this.NonInteractBegin = 0.0f;
        this.TotalDistance = 0.0f;
        this.OriginHighY = 0.0f;
        this.IsPlaying = false;
        this.IsDropping = false;
    }
}