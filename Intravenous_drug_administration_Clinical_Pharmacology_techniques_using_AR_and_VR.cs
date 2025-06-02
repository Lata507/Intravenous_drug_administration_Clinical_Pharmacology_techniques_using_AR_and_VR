// VR Interaction Setup with XR Toolkit
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
[RequireComponent(typeof(XRGrabInteractable))]
public class VRGrab : MonoBehaviour
{
 private XRGrabInteractable grabInteractable;
 void Awake()
 {
 grabInteractable = GetComponent<XRGrabInteractable>();
 grabInteractable.selectEntered.AddListener(OnGrab);
 grabInteractable.selectExited.AddListener(OnRelease);
 }
 private void OnGrab(SelectEnterEventArgs args)
 {
 Debug.Log("Object grabbed: " + gameObject.name);
 }
 private void OnRelease(SelectExitEventArgs args)
 {
 Debug.Log("Object released: " + gameObject.name);
 }
}

//  Accurate Needle Attachment to Vein
using UnityEngine;
public class NeedleAttach : MonoBehaviour
{
 public Transform needlePoint;
 public Transform veinPoint;
 public float attachmentThreshold = 0.005f;
 public bool isAttached = false;
 void Update()
 {
 if (!isAttached && Vector3.Distance(needlePoint.position, veinPoint.position) <
attachmentThreshold)
 {
 AttachNeedle();
 }
 }
 void AttachNeedle()
 {
 isAttached = true;
 Debug.Log("Needle successfully attached to the vein.");
 // Lock the needle in position
 transform.position = veinPoint.position;
 transform.rotation = veinPoint.rotation;
 }
}
 

//  Advanced Drug Animation Trigger
using UnityEngine;
public class DrugAnimationTrigger : MonoBehaviour
{
 public Animator animator;
 public string triggerName = "Inject";
 public void TriggerInjectionAnimation()
 {
 if (animator != null)
 {
 animator.SetTrigger(triggerName);
 Debug.Log("Injection animation triggered.");
 }
 }
}
 

//  VR Instruction Panel with Voice Assistance
using UnityEngine;
public class InstructionDisplay : MonoBehaviour
{
 public GameObject instructionPanel;
 public AudioSource voiceInstructions;
 public void ShowInstructions()
 {
 instructionPanel.SetActive(true);
 voiceInstructions?.Play();
 Debug.Log("Instructions shown and audio played.");
 }
 public void HideInstructions()
 {
 instructionPanel.SetActive(false);
 voiceInstructions?.Stop();
 Debug.Log("Instructions hidden.");
 }
}
 

// Haptic Feedback During Injection
using UnityEngine;
using UnityEngine.XR;
public class HapticFeedback : MonoBehaviour
{
 public XRNode controllerNode = XRNode.RightHand;
 public void SendHapticFeedback(float amplitude = 0.7f, float duration = 1.5f)
 {
 InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
 if (device.TryGetHapticCapabilities(out HapticCapabilities capabilities) &&
capabilities.supportsImpulse)
 {
 device.SendHapticImpulse(0, amplitude, duration);
 Debug.Log("Haptic feedback sent.");
 }
 }
}
 
// VR Patient Feedback System
using UnityEngine;
public class PatientFeedback : MonoBehaviour
{
 public Animator patientAnimator;
 public AudioSource patientVoice;
 public void ReactToInjection()
 {
 patientAnimator?.SetTrigger("React");
 patientVoice?.Play();
 Debug.Log("Patient reacted to injection.");
 }
}
 
//  Logging and Monitoring Module
using UnityEngine;
using System.IO;
public class Logger : MonoBehaviour
{
 private string logFilePath;
 void Start()
 {
 logFilePath = Application.persistentDataPath + "/session_log.txt";
 LogMessage("VR IV session started.");
 }
 public void LogMessage(string message)
 {
 File.AppendAllText(logFilePath, System.DateTime.Now + ": " + message + "\n");
 }
}
 

// Drug Dosage Manager
using UnityEngine;
public class DosageManager : MonoBehaviour
{
 public float maxDosage = 100f;
 private float currentDosage = 0f;
 public void AdministerDose(float dose)
 {
 if (currentDosage + dose <= maxDosage)
 {
 currentDosage += dose;
 Debug.Log("Dose administered: " + dose + "mg");
 }
 else
 {
 Debug.Log("Exceeded max dosage.");
 }
 }
 public float GetRemainingDosage()
 {
 return maxDosage - currentDosage;
 }
}
 
//  Environment Setup with Lighting and Sound
using UnityEngine;
public class EnvironmentSetup : MonoBehaviour
{
 public Light spotlight;
 public AudioSource backgroundSound;
 void Start()
 {
 spotlight.intensity = 1.5f;
 backgroundSound?.Play();
 Debug.Log("Environment initialized with lighting and sound.");
 }
}