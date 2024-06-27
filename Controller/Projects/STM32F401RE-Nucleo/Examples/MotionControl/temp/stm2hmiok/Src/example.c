	/**
		******************************************************************************
		* @file       example.c
		* @date       01/10/2014 12:00:00
		* @brief      Example functions for the X-NUCLEO-IHM02A1
	******************************************************************************
		*
		* COPYRIGHT(c) 2014 STMicroelectronics
		*
		* Redistribution and use in source and binary forms, with or without modification,
		* are permitted provided that the following conditions are met:
		*   1. Redistributions of source code must retain the above copyright notice,
		*      this list of conditions and the following disclaimer.
		*   2. Redistributions in binary form must reproduce the above copyright notice,
		*      this list of conditions and the following disclaimer in the documentation
		*      and/or other materials provided with the distribution.
		*   3. Neither the name of STMicroelectronics nor the names of its contributors
		*      may be used to endorse or promote products derived from this software
		*      without specific prior written permission.
		*
		* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
		* AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
		* IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
		* DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
		* FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
		* DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
		* SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
		* CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
		* OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
		* OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
		*
		******************************************************************************
		*/

	#include "example.h"
	#include "example_usart.h"
	#include "params.h"
	#include "xnucleoihm02a1.h"
	uint16_t BSP_ST1S14_PGOOD(void);
	uint32_t usrPow(uint8_t base, uint8_t exponent);
	double Hex2Dec(char* msByte);

	 StepperMotorBoardHandle_t *StepperMotorBoardHandle;
		MotorParameterData_t *MotorParameterDataGlobal, *MotorParameterDataSingle;
		
	 void USART_HmiMessage(void);


	void act1(void)
	{
		uint8_t c=0,b=0;
		uint32_t  value;
		uint32_t Step;
		uint8_t i;
		uint8_t board, device;
		 uint16_t  Status;
		uint8_t id;
		uint32_t AbsPos;
		
		
		
		USART_Transmit(&huart2, (uint8_t* )"ACT1START\n \n\n\\n\r");
		USART_Transmit(&huart2, (uint8_t* )"Initial value  0x0000 \r\n");


	for (i=0; i<=1;i++)
				{
			 value = L6470_GetParam(i, (eL6470_RegId_t) 0);
					
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}
		
		/****************************************************************************/

		for (board = EXPBRD_ID(0); board <= 1; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			
			for (device = L6470_ID(0); device <= L6470_ID(L6470DAISYCHAINSIZE-1); device++)
			{
			 
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
			 
				for (i=0; i<1; i++)
				{
					StepperMotorBoardHandle->Command->GoTo(board, device, 0X3200);
					while(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, device, BUSY_ID) == 0);
					HAL_Delay(1000);
				}
			}
		}

	USART_Transmit(&huart2, (uint8_t* )"GoTo 0x3200 \r\n");
		for (i=0; i<=1;i++)
				{
			 value = L6470_GetParam(i, (eL6470_RegId_t) 0);
					
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2,  (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}
		
		

		for (board = EXPBRD_ID(0); board <= 1; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			
			for (device = L6470_ID(0); device <= L6470_ID(L6470DAISYCHAINSIZE-1); device++)
			{
			 // Get the parameters for the motor connected with the actual stepper motor driver of the actual stepper motor expansion board 
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
				AbsPos=Position_2_AbsPos(-0x3200);
				
				for (i=0; i<1; i++)
				{
					
					StepperMotorBoardHandle->Command->GoTo(board, device, AbsPos);
					
					
					
					while(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, device, BUSY_ID) == 0);
					HAL_Delay(1000);
				}
			}
		
		}

		 
		USART_Transmit(&huart2, (uint8_t* )"GoTo -0x3200==0x3FCE00 \r\n");
	for (i=0; i<=1;i++)
				{
			 value = L6470_GetParam(i, (eL6470_RegId_t) 0);
					
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2,  (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}



			
		HAL_Delay(1000);
		
		
		
		
		
	for (board = EXPBRD_ID(0); board <= 1; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			for (device = L6470_ID(0); device <= L6470_ID(L6470DAISYCHAINSIZE-1); device++)
			{
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
				
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareGoToDir(device, L6470_DIR_FWD_ID, 0x6400);
			
			}
			
			StepperMotorBoardHandle->Command->PerformPreparedApplicationCommand();
		
		}
		
		
		
		
		
		
		
		
	USART_Transmit(&huart2, (uint8_t* )"PrepareGoToDir FW 0x6400 \r\n");


	for (i=0; i<=1;i++)
				{
			 value = L6470_GetParam(i, (eL6470_RegId_t) 0);
					
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}

		for (i=0; i<=1;i++)
				{
				Status=L6470_GetStatus(i);
				USART_Transmit(&huart2, (uint8_t* )"Status: ");
				USART_Transmit(&huart2, num2hex(Status, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(1000);
				}

	USART_Transmit(&huart2, (uint8_t* )"ACT1end\n\n\n ");

	}





		

	void act2(void)
	{
		 uint8_t c=1,b=0;
		uint32_t  value;
		uint32_t Step;
	 
		
		uint8_t i;
		uint8_t board, device;
		uint16_t  Status;
		uint8_t id;
		uint32_t AbsPos;
		
	 
		
		
		USART_Transmit(&huart2, (uint8_t* )"ACT2START\n \n\r");
		
		USART_Transmit(&huart2, (uint8_t* )"Initial value \r\n");


	for (i=0; i<=2;i++)
				{
			 value = L6470_GetParam(i, (eL6470_RegId_t) 0);
					
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}
		/****************************************************************************/
	 
		for (board = EXPBRD_ID(0); board <= 2; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			
			AbsPos=Position_2_AbsPos(-0x6400);
			for (device = L6470_ID(0); device <= L6470_ID(L6470DAISYCHAINSIZE-1); device++)
			{
			 
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
				
					StepperMotorBoardHandle->Command->GoToDir(board, device, L6470_DIR_REV_ID,AbsPos); //
				
					while(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, device, BUSY_ID) == 0);
				
					HAL_Delay(500);
			}
		}
				
		
		
		
		USART_Transmit(&huart2, (uint8_t* )"GoToDir REV -0x6400==0x3F9C00 \r\n");
					
		for (i=0; i<=2;i++)
				{
			 value = L6470_GetParam(i, (eL6470_RegId_t) 0);
		
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}
				
				
	HAL_Delay(1000);

			for (board = EXPBRD_ID(0); board <= 2; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			for (device = L6470_ID(0); device <=1; device++)
			{
				
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
				if(board==0)
				{
				if(device==0)
					{
				
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareGoHome(device);
					}
				if(device==1){
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareRun(device,L6470_DIR_REV_ID,Step_s_2_Speed(200));}
				//HAL_Delay(500);
				}
				
				if(board==1){	
					
				if(device==0){
			
			
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareMove(device,L6470_DIR_REV_ID,128000);
				}
				if(device==1){
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareMove(device,L6470_DIR_FWD_ID,128000);}
				//
			}
			
			if(board==2){	
					
				if(device==0)
					{
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareRun(device,L6470_DIR_FWD_ID,Step_s_2_Speed(200));
				}
				if(device==1){
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareMove(device,L6470_DIR_FWD_ID,25600*2);}	
			}
		
			}
			 
		//StepperMotorBoardHandle->Command->PerformPreparedApplicationCommand();
			 BSP_L6470_PerformPreparedApplicationCommand(board);

		// if(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, 1, MOT_STATUS_ID) != 0x00);
			
		}
		
			HAL_Delay(5000);
				
		for (board = EXPBRD_ID(0); board <= 2; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			for (device = L6470_ID(0); device <=1; device++)
			{
				
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
			 StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareHardStop(device);
			}
			 
			 //StepperMotorBoardHandle->Command->PerformPreparedApplicationCommand();
			 BSP_L6470_PerformPreparedApplicationCommand(board);
		
		}
	 HAL_Delay(1000);
		
		USART_Transmit(&huart2, (uint8_t* )"SoftStop:\n ");
	for (board = EXPBRD_ID(0); board <= 2; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			for (device = L6470_ID(0); device <=1; device++)
			{
				
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
			 StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareGoHome(device);
			}
			 
		BSP_L6470_PerformPreparedApplicationCommand(board);
			 
		
		}
		
		
		
				

		USART_Transmit(&huart2, (uint8_t* )"gohome:\n ");
				
		HAL_Delay(5000);
		
		
		for (i=0; i<=2;i++)
				{
				value = L6470_GetParam(i, (eL6470_RegId_t) 0);
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) 0));
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);
				}
		
			 for (i=0; i<=2;i++)
				{
				Status=L6470_GetStatus(i);
				USART_Transmit(&huart2, (uint8_t* )"Status: ");
				USART_Transmit(&huart2, num2hex(Status, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(1000);
				}
		 USART_Transmit(&huart2, (uint8_t* )"ACT2end\n\n\r ");

	}


	void act3(void)
	{

		uint32_t  value;
		uint32_t Step;

		uint8_t i,j;
		uint8_t board, device;
		uint16_t  Status;
		uint8_t id;
		uint32_t mark;
		
		
		
		USART_Transmit(&huart2, (uint8_t* )"ACT3 start\r\n");
		for (i=0; i<=1;i++)
				{
			 
				for(j=0;j<=2;j+=2){
				value = L6470_GetParam(i, (eL6470_RegId_t) j);	
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) j));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);}
				
				}
		/****************************************************************************/
		
		
		
		
		
		
		for (board = EXPBRD_ID(0); board <= 0; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			mark=Position_2_AbsPos(-0xC800);
			for (device = L6470_ID(0); device <= L6470_ID(L6470DAISYCHAINSIZE-1); device++)
			{
			
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
				StepperMotorBoardHandle->Command->SetParam(board, device,0x2,mark);
					HAL_Delay(500);
			}
		}
				
		
		
		for (board = EXPBRD_ID(0); board <= 0; board++)
		{
			StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(board);
			for (device = L6470_ID(0); device <=1; device++)
			{
				MotorParameterDataSingle = MotorParameterDataGlobal+((board*L6470DAISYCHAINSIZE)+device);
				StepperMotorBoardHandle->StepperMotorDriverHandle[device]->Command->PrepareGoMark(device);

				HAL_Delay(500);
			}
			
			StepperMotorBoardHandle->Command->PerformPreparedApplicationCommand();
		while(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, 1, MOT_STATUS_ID) != 0x00);
		while(StepperMotorBoardHandle->Command->CheckStatusRegisterFlag(board, 0,  MOT_STATUS_ID) != 0x00);
		}
			 
		
		
		USART_Transmit(&huart2, (uint8_t* )"Go mark -0xC800 == 0x3F3800\r\n");
		for (i=0; i<=1;i++)
				{
			 
				for(j=0;j<=2;j+=2){
				value = L6470_GetParam(i, (eL6470_RegId_t) j);	
				USART_Transmit(&huart2, L6470_GetRegisterName((eL6470_RegId_t) j));
				USART_Transmit(&huart2, num2hex(i, BYTE_F) );
				USART_Transmit(&huart2, (uint8_t* )": ");
				USART_Transmit(&huart2, num2hex(value, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(500);}
				
				}
		
		
		
		
		for (i=0; i<=1;i++)
				{
				Status=L6470_GetStatus(i);
				USART_Transmit(&huart2, (uint8_t* )"Status: ");
				USART_Transmit(&huart2, num2hex(Status, DOUBLEWORD_F));
				USART_Transmit(&huart2, (uint8_t* )"\r\n");
				HAL_Delay(1000);
				}
		

		
		USART_Transmit(&huart2, (uint8_t* )"ACT3END\n \n\n\\n\r");
		
	}

	/**
		* @addtogroup MicrosteppingMotor_Example
		* @{
		*/

	/**
		* @addtogroup Example
		* @{
		*/

	/**
		* @defgroup   ExamplePrivateFunctions
		* @brief      Example Private Functions.
		* @{
		*/




	/**
		* @}
		*/ /* End of ExamplePrivateFunctions */

	/**
		* @addtogroup ExamplePrivateFunctions
		* @brief      Example Private Functions.
		* @{
		*/

	/**
		* @addtogroup ExampleExportedFunctions
		* @brief      Example Exported Functions.
		* @{
		*/

	/**
		* @brief  Example no.1 for X-NUCLEO-IHM02A1.
		* @note	Perform a complete motor axis revolution as MPR_1 equal movements,
		*			for each L6470 mounted on all stacked X-NUCLEO-IHM02A1.
		*			At the end of each movement there is a delay of DELAY_1 ms.
		*     	After each motor has performed a complete revolution there is a
		*			delay of DELAY_2 ms.
		*			Now all motors for each X-NUCLEO-IHM02A1 will start at the same
		*			time.
		*			They are going to run at INIT_SPEED for DELAY_3 ms.
		*			After that all motors for each X-NUCLEO-IHM02A1 will get a HardStop
		*			at the same time.
		*			Perform a complete motor axis revolution as MPR_2 equal movements,
		*			for each L6470 mounted on all stacked X-NUCLEO-IHM02A1.
		*			At the end of each movement there is a delay of DELAY_1 ms.
		*			After that all motors for each X-NUCLEO-IHM02A1 will get a HardHiZ
		*			at the same time.
		*/
	void MicrosteppingMotor_Example_01(void)
		{
			uint32_t  value;
			uint16_t  Status;
		  MotorParameterDataGlobal = GetMotorParameterInitData();
			for ( uint8_t k = 0; k < EXPBRD_MOUNTED_NR; k++)
			{
				StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(EXPBRD_ID(k));
				MotorParameterDataSingle = MotorParameterDataGlobal+(k*L6470DAISYCHAINSIZE);
				StepperMotorBoardHandle->Config(MotorParameterDataSingle);
			}
			//act1();
			//act2();
			//act3();
		
			
	#define FRAME_LENGTH 10
		//uint8_t buffer[FRAME_LENGTH]={0xAA,0xa0,0x45,0x06,0xAA};
		//HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
			while (1) 
		{
		/*buffer
		0=stratchar
		1=action
		2=board
		3=device
		*/
			
			 //char A[100]="1234";
			//USART_Transmit(&huart2, (uint8_t* )"ACT3END\r\n");
			 //HAL_UART_Transmit(&huart2,(uint8_t* )buffer,sizeof(buffer),0xff);
//			USART_Transmit(&huart2,(uint8_t* )buffer);
uint8_t buffer[FRAME_LENGTH]={0xAA,0xa0,0x45,0x03,0xAA,0xab,0xac,0xad,0xae,0xA0};
HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff); 
HAL_Delay(1000);		
uint8_t bu[FRAME_LENGTH]={0xAA,0xa0,0x45,0x07,0xAA,0xab,0xac,0xad,0xae,0xfA};
HAL_UART_Transmit(&huart2,(uint8_t*)bu,sizeof(buffer),0xff); 
			
		while (1) 
{
		/*buffer
		0=stratchar
		1=action
		2=board
		3=device
		*/
			int position;
			int h;
			int step,step_s;
			double values,speed,acc,Speed;
			
		
			
			 if(HAL_UART_Receive(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff)==HAL_OK)
			{ //USART_Transmit(&huart2, (uint8_t* ));
		    
		
					HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff); 
			}
}
		
		
		
		
		
		
		
		
		
		
		
		
		
		}
	 }	 
		
	
	/**
		* @}
		*/ /* End of ExampleExportedFunctions */


	/**
		* @brief  This function return the ADC conversion result about the ST1S14 PGOOD.
		* @retval PGOOD The number into the range [0, 4095] as [0, 3.3]V.
		* @note   It will just return 0 if USE_ST1S14_PGOOD is not defined.
		*/
	
	 

	 
	 
	 uint16_t BSP_ST1S14_PGOOD(void)
	{
	#ifdef USE_ST1S14_PGOOD
		HAL_ADC_Start(&HADC);
		HAL_ADC_PollForConversion(&HADC, 100);
		
		return HAL_ADC_GetValue(&HADC);
	#else
		return 0;
	#endif
	}
	/**
		* @brief  Calculates the power of a number.
		* @param  base      the base
		* @param  exponent  the exponent
		* @retval power     the result as (base^exponent)
		* @note   There is not OVF control.
		*/
	uint32_t usrPow(uint8_t base, uint8_t exponent)
	{
		uint8_t i;
		double power = 1;
		
		for (i=0; i<exponent; i++)
			power *= base;
		
		return power;
	}
	
			double Hex2Dec(char* msByte){
			
			double sum;
			int flagcount;
			for(int i=0;flagcount<3;){
				if(msByte[i]==(char)0xff)flagcount++;
				else
				flagcount=0;	
				sum+=((msByte[i]&0xf0)>>4)*usrPow(16,2*i+1);
				//USART_Transmit(&huart2, num2hex(sum, BYTE_F));
				//USART_Transmit(&huart2, (uint8_t* )"\n");
				sum+=(msByte[i]&0x0f)*usrPow(16,2*i);
				i++;
				if(flagcount==3){
					int last=i;
					for(int j=0;j<3;j++){
					sum-=(msByte[last]&0xf0)*usrPow(16,2*last);
					sum-=(msByte[last]&0x0f)*usrPow(16,2*last+1);
					last--;
					}
				}
			
			}					

				return sum;
		}
			
		


		
	/**
		* @brief  EXTI line detection callbacks.
		* @param  GPIO_Pin: Specifies the port pin connected to corresponding EXTI line.
		* @retval None
		*/
	void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
	{
		switch (GPIO_Pin)
		{
		case GPIO_PIN_13:
			BSP_EmergencyStop();
			break;
		case L6470_nBUSY_SYNC_GPIO_PIN:
			BSP_L6470_BusySynchEventManager();
			break;
		case L6470_nFLAG_GPIO_PIN:
			BSP_L6470_FlagEventManager();
			break;
		}
	}

	/**
		* @}
		*/ /* End of ExamplePrivateFunctions */

	/**
		* @}
		*/ /* End of Example */

	/**
		* @}
		*/ /* End of MicrosteppingMotor_Example */

	/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
