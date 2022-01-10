import React from 'react';
import RegisterTemplate from "../../templates/RegisterTemplate";
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

export default class Register extends React.Component {
    render() {
        return (
            <RegisterTemplate />
        )
    }
}
