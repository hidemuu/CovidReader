import React from 'react';
import { Grid } from '@material-ui/core'
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

import RegisterBasic from "./RegisterBasic";
import RegisterOptional from "./RegisterOptional";
import RegisterConfirm from "./RegisterConfirm";

function getSteps() {
    return [
        '基本項目',
        '任意項目',
        '入力確認'
    ];
}

function getStepContent(stepIndex, handleNext, handleBack) {
    switch (stepIndex) {
        // case 0:
        //     return <RegisterBasic handleNext={handleNext} />;
        // case 1:
        //     return <RegisterOptional handleNext={handleNext} handleBack={handleBack} />;
        // case 2:
        //     return <RegisterConfirm handleBack={handleBack} />;
        // default:
        //     return 'Unknown stepIndex';
        case 0:
            return 'フォーム　1 のコンテンツを表示';
        case 1:
            return 'フォーム　2 のコンテンツを表示';
        case 2:
            return 'フォーム　3 のコンテンツを表示';
        default:
            return 'Unknown stepIndex';
    }
}

export const UserInputData = React.createContext();

function Register() {
    const [currentState, setCurrentState] = React.useState({});
    const value = {
        currentState,
        setCurrentState
    };
    const [activeStep, setActiveStep] = React.useState(0);
    const steps = getSteps();
    const handleNext = () => {
        setActiveStep((prevActiveStep) => prevActiveStep + 1);
    };
    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1);
    };
    const handleReset = () => {
        setActiveStep(0);
    };
    return (
        <Grid container>
            <Grid sm={2}/>
            <Grid lg={8} sm={8} spacing={10}>
                <Stepper activeStep={activeStep} alternativeLabel>
                    {steps.map((label) => (
                        <Step key={label}>
                            <StepLabel>{label}</StepLabel>
                        </Step>
                    ))}
                </Stepper>
                <UserInputData.Provider value={value}>
                    { getStepContent(activeStep, handleNext, handleBack)}
                </UserInputData.Provider>
                {activeStep === steps.length ? (
                    <div>
                        <Typography >全ステップの表示を完了</Typography>
                        <Button onClick={handleReset}>リセット</Button>
                    </div>
                ) : (
                    <div>
                        <Typography >{getStepContent(activeStep)}</Typography>
                        <Button
                            disabled={activeStep === 0}
                            onClick={handleBack}
                        >
                            戻る
                        </Button>
                        <Button variant="contained" color="primary" onClick={handleNext}>
                            {activeStep === steps.length - 1 ? '送信' : '次へ'}
                        </Button>
                    </div>
                )}
            </Grid>
        </Grid>
    )
}

export default Register

