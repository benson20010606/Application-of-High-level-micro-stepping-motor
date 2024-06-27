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
	uint32_t usrPow(uint16_t base, uint8_t exponent);
	double Hex2Dec(char* msByte);
  unsigned int UintHex2Dec(uint8_t Byte[]);
  void value2Hextwo( int value,uint8_t* buffer);
	void Limit_Touch_Reset(int dir,uint8_t* buffer);
	void USART_HmiMessage(void);
	void limit_command();
	
	StepperMotorBoardHandle_t *StepperMotorBoardHandle;
	MotorParameterData_t *MotorParameterDataGlobal, *MotorParameterDataSingle;
	
	int Home_X=0;
	int Home_Y=0;
	int Home_Z=0;
	int Home_U=0;
	int LXmax=0;
	int LYmax=0;
	int LZmax=0;
	int LUmax=0;
	int LXmin=0;
	int LYmin=0;
	int LZmin=0;
	int LUmin=0;
	
	int Stop_Dir_x=0;
	int Stop_Dir_y=0;
	int Stop_Dir_z=0;
	int Stop_Dir_u=0;
	
	int LXmaxtouch=0;
	int LYmaxtouch=0;
	int LZmaxtouch=0;
	int LUmaxtouch=0;
	
	int LXmintouch=0;
	int LYmintouch=0;
	int LZmintouch=0;
	int LUmintouch=0;
	
	int Hometouch_X=0;
	int Hometouch_Y=0;
	int Hometouch_Z=0;
	int Hometouch_U=0;
	
	int Move_value=0;
	int Move_step=0;
			
	int Home_Reset_Step=20;		
	int Home_Reset_Speed=50;	
	uint8_t limit_buffer[10]={0x55,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};

///////////////////////////////////////////////////////


///////////////////////////////////////////////////////
	void MicrosteppingMotor_Example_01(void)
	{
				USART_PrintRegisterValues(0,0);
				uint32_t  value;
				uint16_t  Status;
				MotorParameterDataGlobal = GetMotorParameterInitData();
				for ( uint8_t k = 0; k < EXPBRD_MOUNTED_NR; k++)
				{
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(EXPBRD_ID(k));
					MotorParameterDataSingle = MotorParameterDataGlobal+(k*L6470DAISYCHAINSIZE);
					StepperMotorBoardHandle->Config(MotorParameterDataSingle);
				}
				 USART_PrintAllRegisterValues();
					#define FRAME_LENGTH 10
					
						//uint8_t buffer[FRAME_LENGTH]={0xAA,0xa0,0x45,0x06,0xAA};
						//HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
				while (1) 
				{
	   
						 limit_command();


						uint8_t buffer[FRAME_LENGTH]={0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF};
						uint8_t temp[FRAME_LENGTH]={0xAA,0xa0,0x45,0x03,0xAA,0xab,0xac,0xad,0xae,0xA0};
						//HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff); 
						uint8_t REG[9]={0x00,0x02,0x03,0x04,0x05,0x06,0x07,0x15,0x18};
							int position;
							int h;
							int step,step_s;
							double values,speed,acc,Speed;
							
							

				if(HAL_UART_Receive(&huart2,buffer, sizeof(buffer),0xff)==HAL_OK)
					{ //USART_Transmit(&huart2, (uint8_t* ));   

						 for (int i=0;i<9;i++)
						{
							temp[i]=buffer[i];		 
						}
				
				if(buffer[0] == 0x55)
						{
							switch(buffer[1])
							{
								
								case 0x01://Move
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								//MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								Move_value= UintHex2Dec(&buffer[0]);
								Move_step=Position_2_AbsPos(Move_value);
								//StepperMotorBoardHandle->StepperMotorDriverHandle[buffer[3]]->Command->PrepareMove(buffer[3],buffer[4],step);//buffer[4]=Direction
								BSP_L6470_Move(buffer[2],buffer[3],buffer[4],Move_step);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
							
								
								
								case 0x02://GoHome
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
				
								//StepperMotorBoardHandle->StepperMotorDriverHandle[buffer[3]]->Command->PrepareGoHome(buffer[3]);//buffer[4]=Direction
								BSP_L6470_GoHome(buffer[2],buffer[3]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								
								case 0x03://HardStop
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								//StepperMotorBoardHandle->StepperMotorDriverHandle[buffer[3]]->Command->PrepareHardStop(buffer[3]);
							
								BSP_L6470_HardStop(buffer[2],buffer[3]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								
								case 0x4://SoftStop
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								//StepperMotorBoardHandle->StepperMotorDriverHandle[buffer[3]]->Command->PrepareSoftStop(buffer[3]);
								BSP_L6470_SoftStop(buffer[2],buffer[3]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								
								case 0x5://SoftHiZ
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								//StepperMotorBoardHandle->StepperMotorDriverHandle[buffer[3]]->Command->PrepareSoftHiZ(buffer[3]);
								BSP_L6470_SoftHiZ(buffer[2],buffer[3]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								
								case 0x6://HardHiZ
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								//StepperMotorBoardHandle->StepperMotorDriverHandle[buffer[3]]->Command->PrepareHardHiZ(buffer[3]);
								BSP_L6470_HardHiZ(buffer[2],buffer[3]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
							
								
								case 0x7://goto
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								values= UintHex2Dec(&buffer[0]);
								if(buffer[4]==0x00)
									values*=-1;
								step =Position_2_AbsPos(values);
								BSP_L6470_GoTo(buffer[2],buffer[3],step);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								
								case 0x8://gomark
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								BSP_L6470_GoMark(buffer[2],buffer[3]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								case 0x9://run dir no set
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								values= UintHex2Dec(&buffer[0]);
								speed =Step_s_2_Speed(values);
								BSP_L6470_Run(buffer[2],buffer[3],0,speed);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								
								
								case 0xa:
								{
								StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
								MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
								values=BSP_L6470_GetStatus(buffer[2],buffer[3]);
								value2Hextwo(values,&buffer[0]);
								HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
								break;
								}
								
								//setpram
								case 0xaa:
								{
		//						StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
		//				 		MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
										if(buffer[4]==0x0) // abspos
										{
												values= UintHex2Dec(&buffer[0]);
												 if (buffer[5] == 0x00)
													{
															values=values*1;
													}
													else if (buffer[5] == 0x01)
													{
												
														values *= -1;
													}
												values=Position_2_AbsPos(values);
												BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
												value2Hextwo(values,&buffer[0]);
												HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										}
										else if(buffer[4]==0x2)//mark
										{
											values= UintHex2Dec(&buffer[0]);
											values= Position_2_AbsPos(values);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
											
											HAL_Delay(50);
											values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
											values=AbsPos_2_Position(values);
											value2Hextwo(values,&buffer[0]);
											HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
											HAL_Delay(50);
											
										}
										else if(buffer[4]==0x3)//speed
										{ 
											values= UintHex2Dec(&buffer[0]);
											values=Step_s_2_Speed(values);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
										HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										}
										else if(buffer[4]==0x4)//acc
										{
											
											values= UintHex2Dec(&buffer[0]);
											values=Step_s2_2_Acc(values);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
											
											HAL_Delay(50);
											values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
											values=Acc_2_Step_s2(values);
											value2Hextwo(values,&buffer[0]);
											HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
											HAL_Delay(50);
											
										}
										else if(buffer[4]==0x5)//dec
										{
											values= UintHex2Dec(&buffer[0]);
											values=Step_s2_2_Dec(values);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
											
											
											HAL_Delay(50);
											values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
											values=Dec_2_Step_s2(values);
											value2Hextwo(values,&buffer[0]);
											HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
											HAL_Delay(50);
									
										}
										else if(buffer[4]==0x6)//maxspeed
										{
											values= UintHex2Dec(&buffer[0]);
											values=Step_s_2_MaxSpeed(values);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
											
											HAL_Delay(50);
											values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
											values=MaxSpeed_2_Step_s(values);
											value2Hextwo(values,&buffer[0]);
											HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
											HAL_Delay(50);
										
										
											
										}
										else if(buffer[4]==0x7)//minspeed
										{
											values= UintHex2Dec(&buffer[0]);
											values=Step_s_2_MinSpeed(values);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
											HAL_Delay(50);
											
											values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
											values=MinSpeed_2_Step_s(values);
											value2Hextwo(values,&buffer[0]);
											HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
											HAL_Delay(50);
										
										}
										else if(buffer[4]==0x15)//stepmode
										{
											values= UintHex2Dec(&buffer[0]);
											BSP_L6470_SetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4],values);
											HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										
											
										}
										break;
									}
								
								
								// FRIST TIME getpram 
								case 0xbb:
								{
										StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
										MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
									 
										buffer[4]=0x4;//acc
										values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
										values=Acc_2_Step_s2(values);
										value2Hextwo(values,&buffer[0]);
										HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										HAL_Delay(50);
											
										buffer[4]=0x5;//dec
										values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
										values=Dec_2_Step_s2(values);
										value2Hextwo(values,&buffer[0]);
										HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										HAL_Delay(50);
											
											
										buffer[4]=0x6;//max
										values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
										values=MaxSpeed_2_Step_s(values);
										value2Hextwo(values,&buffer[0]);
										HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										HAL_Delay(50);
											
											
										buffer[4]=0x7;//min
										values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
										values=MinSpeed_2_Step_s(values);
										value2Hextwo(values,&buffer[0]);
										HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										HAL_Delay(50);
										
											
										buffer[4]=0x15;//stepmode
										values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
										value2Hextwo(values,&buffer[0]);
										HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
										HAL_Delay(50);
										
									break;
								
							}
								//getpramtest
								case 0xcc:
								{
									StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
									MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
									
									buffer[2]=0x00;
									buffer[3]=0x00;
									
									buffer[4]=0x0;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=AbsPos_2_Position(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

									buffer[4]=0x3;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=Speed_2_Step_s(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);	
									HAL_Delay(10);

											
									buffer[4]=0x18;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

									buffer[2]=0x00;
									buffer[3]=0x01;
											
									buffer[4]=0x0;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=AbsPos_2_Position(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

									buffer[4]=0x3;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=Speed_2_Step_s(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

											
									buffer[4]=0x18;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);	
									HAL_Delay(10);
									
									buffer[2]=0x01;
									buffer[3]=0x00;
											
									buffer[4]=0x0;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=AbsPos_2_Position(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

									buffer[4]=0x3;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=Speed_2_Step_s(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);
				
									buffer[4]=0x18;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);
									
											
									buffer[2]=0x01;
									buffer[3]=0x01;
											
									buffer[4]=0x0;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=AbsPos_2_Position(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

									buffer[4]=0x3;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									values=Speed_2_Step_s(values);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									HAL_Delay(10);

											
									buffer[4]=0x18;
									values=BSP_L6470_GetParam((uint8_t)buffer[2],(uint8_t)buffer[3],(eL6470_RegId_t)buffer[4]);
									value2Hextwo(values,&buffer[0]);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);

									HAL_Delay(10);
											
									//BSP_L6470_CheckStatusRegisterFlag(0,0,0);
								break;
							}
								//home reset
								case 0x22:
								{
									StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(buffer[2]);
									MotorParameterDataSingle = MotorParameterDataGlobal+((buffer[2]*L6470DAISYCHAINSIZE)+buffer[3]);
									 int dir;
							
								 if(buffer[2]==0x00&&buffer[3]==0x00)
									{
									
										Home_X=1;
									
										if(buffer[5]==0x0)
										 {
												Stop_Dir_x=0;
										 }
										 else if(buffer[5]==0x1)
										 {
												Stop_Dir_x=1;
										 }
									 
									}
										
								 if(buffer[2]==0x00&&buffer[3]==0x01)
									{
									
										Home_Y=1;
									
										if(buffer[5]==0x0)
										 {
												Stop_Dir_y=0;
										 }
										 else if(buffer[5]==0x1)
										 {
												Stop_Dir_y=1;
										 }
									 
									}
								 
								
								 if(buffer[2]==0x01&&buffer[3]==0x00)
									{
									
										Home_Z=1;
									
										if(buffer[5]==0x0)
										 {
												Stop_Dir_z=0;
										 }
										 else if(buffer[5]==0x1)
										 {
												Stop_Dir_z=1;
										 }
									 
									} 
								 if(buffer[2]==0x01&&buffer[3]==0x01)
									{
									
										Home_U=1;
									
										if(buffer[5]==0x0)
										 {
												Stop_Dir_u=0;
										 }
										 else if(buffer[5]==0x1)
										 {
												Stop_Dir_u=1;
										 }
									 
									}
								 
								if(buffer[4]==0x00)
								{
									dir=0;
								}
								else if(buffer[4]==0x01)
								{
									dir=1;
								}
								
								Home_Reset_Step= UintHex2Dec(&buffer[0]);
								speed =Step_s_2_Speed(150);
								BSP_L6470_Run(buffer[2],buffer[3],dir,speed);
								break;
								}
								
								case 0x23:
								{
								 int dir;
								 if(buffer[4]==0)
								 {
									 dir=1;
								 }
								 else if(buffer[4]==1)
								 {
										dir=0;
										
									 
								 }
								//0CCW
								//1 CW
									Limit_Touch_Reset(dir,&buffer[0]);
								 	Move_value= UintHex2Dec(&buffer[0]);
									Move_step=Position_2_AbsPos(Move_value);
									step =Position_2_AbsPos(Move_step);
									BSP_L6470_Move(buffer[2],buffer[3],dir,step);
									HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff);
									break;
								}
							

							
								case 0x24: //home reset Speed
								{
									Home_Reset_Speed=UintHex2Dec(&buffer[0]);
								}
								
							}
						}
							//HAL_UART_Transmit(&huart2,(uint8_t*)buffer,sizeof(buffer),0xff); 
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
	
	 
void Limit_Touch_Reset(int dir,uint8_t* buffer)
	{
		if(dir==0)
		{
			
			if(buffer[2]==0x0&&buffer[3]==0x0)
				LXmaxtouch=0;
			else if(buffer[2]==0x0&&buffer[3]==0x1)
				LYmaxtouch=0;
			else if(buffer[2]==0x1&&buffer[3]==0x0)
				LZmaxtouch=0;
			else if(buffer[2]==0x1&&buffer[3]==0x1)
				LUmaxtouch=0;
				
		}
		else if(dir==1)
		{
			if(buffer[2]==0x0&&buffer[3]==0x0)
				LXmintouch=0;
			else if(buffer[2]==0x0&&buffer[3]==0)
				LYmintouch=0;
			else if(buffer[2]==0x1&&buffer[3]==0x0)
				LZmintouch=0;
			else if(buffer[2]==0x1&&buffer[3]==0x1)
				LUmintouch=0;
		
		}
	}
	 
unsigned int UintHex2Dec(uint8_t* Byte)
	{
		unsigned int value;
		for(int i=0;i<4;i++)
		{
		value+=Byte[i+6]*usrPow(256,i);
		}
		return value;
	}		
	
void value2Hextwo(int value,uint8_t* buffer)
	{
	  buffer[6]=(value & 0xff);
		buffer[7]=(uint16_t)((value & 0xff00) >> 8);
		buffer[8]=(uint16_t)((value & 0xff0000) >> 16);
		buffer[9]=(uint16_t)((value & 0xff000000) >> 24);
		//return buffer ;
	}
	 
	
	
	
	
	
	
	
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
uint32_t usrPow(uint16_t base, uint8_t exponent)
	{
		uint16_t i;
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
	
		
		
		
		


		
		uint32_t speed;
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
		/////////////////////limit	
	
				case GPIO_PIN_2://+LY
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(0,1);
					if(Home_Y==1)
					{	
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(0,1,0,speed);
					}
					else
					{
							LYmax=1;
					}
					LYmaxtouch=1;
					break;
				
				case GPIO_PIN_3://HY
					if(Home_Y==1)
						{	
							StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
							BSP_L6470_HardStop(0,1);
							if(Stop_Dir_y==0)
							{
								if(Hometouch_Y==0)
								{
									BSP_L6470_Move(0,1,0,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(0,1,21)));
									Hometouch_Y=1;
								}
								else if(Hometouch_Y==1)
								{
									Home_Y=2;
									BSP_L6470_ResetPos(0,1);
									Hometouch_Y=0;
									LYmintouch=0;
								}
							}
							else if(Stop_Dir_y==1)
							{
								if(Hometouch_Y==0)
								{
									BSP_L6470_Move(0,1,1,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(1,0,21)));
									Hometouch_Y=1;
								}
								else if(Hometouch_Y==1)
								{
									Home_Y=2;
									BSP_L6470_ResetPos(0,1);
									Hometouch_Y=0;
									LYmaxtouch=0;
								}
							}
	
						}
					break;
				
				case GPIO_PIN_4://-LX
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(0,0);
					
					if(Home_X==1)
						{	
							
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(0,0,1,speed);
						}
					else
						{
							LXmin=1;
						}
						LXmintouch=1;
					break;
				
				case GPIO_PIN_5://HX
					
					if(Home_X==1)
						{	
							StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
							BSP_L6470_HardStop(0,0);
							if(Stop_Dir_x==0)
							{
								if(Hometouch_X==0)
								{
									BSP_L6470_Move(0,0,0,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(1,0,21)));
									Hometouch_X=1;
								}
								else if(Hometouch_X==1)
								{
									Home_X=2;
									BSP_L6470_ResetPos(0,0);
									Hometouch_X=0;
									LXmintouch=0;
								}
							}
							else if(Stop_Dir_x==1)
							{
								if(Hometouch_X==0)
								{
									BSP_L6470_Move(0,0,1,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(0,0,21)));
									Hometouch_X=1;
								}
								else if(Hometouch_X==1)
								{
									Home_X=2;
									BSP_L6470_ResetPos(0,0);
									Hometouch_X=0;
									LXmaxtouch=0;
								}
							}
	
						}
					break;
				
				case GPIO_PIN_7://-LU
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(1,1);
					
					if(Home_U==1)
						{	
							
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(1,1,1,speed);
						}
					else
						{
							LUmin=1;
						}
						LUmintouch=1;
					break;
				
				case GPIO_PIN_8://+LX
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);

					BSP_L6470_HardStop(0,0);
					if(Home_X==1)
					{	
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(0,0,0,speed);
					}
					else
					{					
							LXmax=1;
					}
					LXmaxtouch=1;
					break;
				
				case GPIO_PIN_9://-LY
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(0,1);
					
					if(Home_Y==1)
						{	
							
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(0,1,1,speed);
						}
					else
						{
							LYmin=1;	
						}
						LYmintouch=1;
					break;
				
				case GPIO_PIN_10://+LU
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(1,1);
				  if(Home_U==1)
					{		
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(1,1,0,speed);
					}
					else
					{
								LUmax=1;
					}
				  LUmaxtouch=1;
					break;
				
				case GPIO_PIN_11://-LZ
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(1,0);
					
					if(Home_Z==1)
						{	
							
							speed =Step_s_2_Speed(150);
							BSP_L6470_Run(1,0,1,speed);
						}
					else
						{
							LZmin=1;
						}
						LZmintouch=1;
					break;
				
				case GPIO_PIN_12://HU
					if(Home_U==1)
						{	
							StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
							BSP_L6470_HardStop(1,1);
							if(Stop_Dir_u==0)
							{
								if(Hometouch_U==0)
								{
									BSP_L6470_Move(1,1,0,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(1,0,21)));
									Hometouch_U=1;
								}
								else if(Hometouch_U==1)
								{
									Home_U=2;
									BSP_L6470_ResetPos(1,1);
									Hometouch_U=0;
									LUmintouch=0;
								}
							}
							else if(Stop_Dir_u==1)
							{
								if(Hometouch_U==0)
								{
									BSP_L6470_Move(1,1,1,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(1,1,21)));
									Hometouch_U=1;
								}
								else if(Hometouch_U==1)
								{
									Home_U=2;
									BSP_L6470_ResetPos(1,1);
									Hometouch_U=0;
									LUmaxtouch=0;
								}
							}
	
						}
					break;
				
				case GPIO_PIN_14://HZ
					if(Home_Z==1)
						{	
							StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
							BSP_L6470_HardStop(1,0);
							if(Stop_Dir_z==0)
							{
								if(Hometouch_Z==0)
								{
									BSP_L6470_Move(1,0,0,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(1,0,21)));
									Hometouch_Z=1;
								}
								else if(Hometouch_Z==1)
								{
									Home_Z=2;
									BSP_L6470_ResetPos(1,0);
									Hometouch_Z=0;
									LZmintouch=0;
								}
							}
							else if(Stop_Dir_z==1)
							{
								if(Hometouch_Z==0)
								{
									BSP_L6470_Move(1,0,1,Home_Reset_Step*usrPow(2,BSP_L6470_GetParam(1,0,21)));
									Hometouch_Z=1;
								}
								else if(Hometouch_Z==1)
								{
									Home_Z=2;
									BSP_L6470_ResetPos(1,0);
									Hometouch_Z=0;
									LZmaxtouch=0;
								}
							}
	
						}
					break;
				
				case GPIO_PIN_15://+LZ
					StepperMotorBoardHandle = BSP_GetExpansionBoardHandle(0);
					BSP_L6470_HardStop(1,0);
					if(Home_Z==1)
					{	
						speed =Step_s_2_Speed(150);
						BSP_L6470_Run(1,0,0,speed);
					}
					else
					{
						LZmax=1;
					}
					LZmaxtouch=1;
					break;
		//////////////////////		
				
		}
}	




void limit_command()
{
			
	/*
		buffer[1]
		L+ 20
		L- 21
		HOME 22		
					
		*/	
		///////////////////
		if(LXmax==1)
		 {
				 limit_buffer[0]=0x55;
				 limit_buffer[1]=0x20;
				 limit_buffer[2]=0x00;
				 limit_buffer[3]=0x00;
				 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
				 
				 LXmax=0;
			   HAL_Delay(10);
			 }
		 
		 if(LYmax==1)
		 {
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x20;
			 limit_buffer[2]=0x00;
			 limit_buffer[3]=0x01;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			 HAL_Delay(10);
			 LYmax=0;
		 }
		 if(LZmax==1)
		 {
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x20;
			 limit_buffer[2]=0x01;
			 limit_buffer[3]=0x00;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			  HAL_Delay(10);
			 LZmax=0;
		 }
		 if(LUmax==1)
		 {
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x20;
			 limit_buffer[2]=0x01;
			 limit_buffer[3]=0x01;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			  HAL_Delay(10);
			 LUmax=0;
		 }
	
//////////////////////////////////
		 if(LXmin==1)
		 {
				 limit_buffer[0]=0x55;
				 limit_buffer[1]=0x21;
				 limit_buffer[2]=0x00;
				 limit_buffer[3]=0x00;
				 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
				  HAL_Delay(10);
				 LXmin=0;
			 }
		 
		 if(LYmin==1)
		 {
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x21;
			 limit_buffer[2]=0x00;
			 limit_buffer[3]=0x01;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			  HAL_Delay(10);
			 LYmin=0;
		 }
		 if(LZmin==1)
		 {
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x21;
			 limit_buffer[2]=0x01;
			 limit_buffer[3]=0x00;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			  HAL_Delay(10);
			 LZmin=0;
		 }
		 if(LUmin==1)
		 {
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x21;
			 limit_buffer[2]=0x01;
			 limit_buffer[3]=0x01;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			  HAL_Delay(10);
			 LUmin=0;
		 }
	
//////////////////////////////////

		 if(Home_X==2)
		 {	 
			 Home_X=0;
				 limit_buffer[0]=0x55;
				 limit_buffer[1]=0x22;
				 limit_buffer[2]=0x00;
				 limit_buffer[3]=0x00;
				  
				 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			 HAL_Delay(10);
			}
		 
		 if(Home_Y==2)
		 {
			 Home_Y=0;
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x22;
			 limit_buffer[2]=0x00;
			 limit_buffer[3]=0x01;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			 HAL_Delay(10);
		 }
		 if(Home_Z==2)
		 {
			 Home_Z=0;
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x22;
			 limit_buffer[2]=0x01;
			 limit_buffer[3]=0x00;
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			 
			 
		 }
		 if(Home_U==2)
		 { Home_U=0;
			 limit_buffer[0]=0x55;
			 limit_buffer[1]=0x22;
			 limit_buffer[2]=0x01;
			 limit_buffer[3]=0x01;
			  
			 HAL_UART_Transmit(&huart2,(uint8_t*)limit_buffer,sizeof(limit_buffer),0xff);
			 HAL_Delay(10);
		 }
	
////////////////////////////////// when home_reset touch + or - limit 
     
		if(BSP_L6470_CheckStatusRegisterFlag(0,0,MOT_STATUS_ID)==0) 
		{
				 if(Hometouch_X==1&&Stop_Dir_x==0)
			{ 
				
				BSP_L6470_HardStop(0,0);
				BSP_L6470_Run(0,0,1,Step_s_2_Speed(Home_Reset_Speed));
			}
			else if(Hometouch_X==1&&Stop_Dir_x==1)
			{	
				
				BSP_L6470_HardStop(0,0);
				BSP_L6470_Run(0,0,0,Step_s_2_Speed(Home_Reset_Speed));
			}
		}

		 
		 
		 
		if(BSP_L6470_CheckStatusRegisterFlag(0,1,MOT_STATUS_ID)==0) 
		{
				 if(Hometouch_Y==1&&Stop_Dir_y==0)
			{ 
				
				BSP_L6470_HardStop(0,1);
				BSP_L6470_Run(0,1,1,Step_s_2_Speed(Home_Reset_Speed));
			}
			else if(Hometouch_Y==1&&Stop_Dir_y==1)
			{	
				
				BSP_L6470_HardStop(0,1);
				BSP_L6470_Run(0,1,0,Step_s_2_Speed(Home_Reset_Speed));
			}
		}
		
		
		if(BSP_L6470_CheckStatusRegisterFlag(1,0,MOT_STATUS_ID)==0) 
		{
				 if(Hometouch_Z==1&&Stop_Dir_z==0)
			{ 
				
				BSP_L6470_HardStop(1,0);
				BSP_L6470_Run(1,0,1,Step_s_2_Speed(Home_Reset_Speed));
			}
			else if(Hometouch_Z==1&&Stop_Dir_z==1)
			{	
				
				BSP_L6470_HardStop(1,0);
				BSP_L6470_Run(1,0,0,Step_s_2_Speed(Home_Reset_Speed));
			}
		}
		
		if(BSP_L6470_CheckStatusRegisterFlag(1,1,MOT_STATUS_ID)==0) 
		{
				 if(Hometouch_U==1&&Stop_Dir_u==0)
			{ 
				
				BSP_L6470_HardStop(1,1);
				BSP_L6470_Run(1,1,1,Step_s_2_Speed(Home_Reset_Speed));
			}
			else if(Hometouch_U==1&&Stop_Dir_u==1)
			{	
				
				BSP_L6470_HardStop(1,1);
				BSP_L6470_Run(1,1,0,Step_s_2_Speed(Home_Reset_Speed));
			}
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
