#include "example.h"
#include "example_usart.h"
#include "params.h"
#include "xnucleoihm02a1.h"

void act1(void){
#define MPR_1     4			  //!< Motor Movements Per Revolution 1st option
#define MPR_2     8			  //!< Motor Movements Per Revolution 2nd option
#define DELAY_1   1000		//!< Delay time 1st option
#define DELAY_2   2500		//!< Delay time 2nd option
#define DELAY_3   10000   //!< Delay time 3rd option
  
  uint32_t Step;
  uint32_t Speed;
  uint8_t MovementPerRevolution;
  uint8_t i;
  uint8_t board, device;
  uint8_t id;
  
  StepperMotorBoardHandle_t *StepperMotorBoardHandle;
  MotorParameterData_t *MotorParameterDataGlobal, *MotorParameterDataSingle;
  
  MotorParameterDataGlobal = GetMotorParameterInitData();
  
  for (id = 0; id < EXPBRD_MOUNTED_NR; id++)
  {
    StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(EXPBRD_ID(id));
    MotorParameterDataSingle = MotorParameterDataGlobal+(id*L6470DAISYCHAINSIZE);
    StepperMotorBoardHandle->Config(MotorParameterDataSingle);
  }
 
  #ifdef NUCLEO_USE_USART
  USART_Transmit(&huart2, (uint8_t *)"Custom values for registers:\r\n");
  USART_PrintAllRegisterValues();
  #endif
  
  /****************************************************************************/
for (board = EXPBRD_ID(0); board <= 0; board++)
  {
    StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
    
    for (device = L6470_ID(0); device <= L6470_ID(L6470DAISYCHAINSIZE-1); device++)
    {
     // Get the parameters for the motor connected with the actual stepper motor driver of the actual stepper motor expansion board 
      MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
      Step = ((uint32_t)MotorParameterDataSingle->fullstepsperrevolution * usrPow(2, MotorParameterDataSingle->step_sel)) /MovementPerRevolution;
      
      for (i=0; i<82; i++)
      {
				//USART_Transmit(&huart2, num2hex(Step, HALFBYTE_F));
     		StepperMotorBoardHandle->Command->Move(board, device, L6470_DIR_FWD_ID, Step);
        while(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, device, BUSY_ID) == 0);
        HAL_Delay(50);
      }
    }
   //S[0]=Step;
	}






}