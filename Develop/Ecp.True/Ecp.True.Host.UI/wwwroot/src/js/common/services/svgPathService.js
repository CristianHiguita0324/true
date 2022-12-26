const svgPaths = (function () {
    const deleteButtonPaths = () => {
        return {
            innerCircleOutline: 'M 9.424877166748047 18.34975624084473 C 4.503677368164063 18.34975624084473 0.4999971687793732 14.34607696533203 0.4999971687793732 9.424877166748047 C '
                + '0.4999971687793732 4.503677368164063 4.503677368164063 0.4999971687793732 9.424877166748047 0.4999971687793732 C 14.34607696533203 0.4999971687793732 '
                + '18.34975624084473 4.503677368164063 18.34975624084473 9.424877166748047 C 18.34975624084473 14.34607696533203 14.34607696533203 18.34975624084473'
                + '9.424877166748047 18.34975624084473 Z',
            innerCircle: 'M 9.424877166748047 0.9999980926513672 C 4.779387474060059 0.9999980926513672 0.9999980926513672 4.779387474060059 0.9999980926513672 '
                + '9.424877166748047 C 0.9999980926513672 14.07036781311035 4.779387474060059 17.84975814819336 9.424877166748047 17.84975814819336 C 14.07036781311035 '
                + '17.84975814819336 17.84975814819336 14.07036781311035 17.84975814819336 9.424877166748047 C 17.84975814819336 4.779387474060059 14.07036781311035 0.9999980926513672 '
                + '9.424877166748047 0.9999980926513672 M 9.424877166748047 -1.9073486328125e-06 C 14.63009738922119 -1.9073486328125e-06 18.84975624084473 4.219656944274902 '
                + '18.84975624084473 9.424877166748047 C 18.84975624084473 14.63009738922119 14.63009738922119 18.84975624084473 9.424877166748047 18.84975624084473 C 4.219656944274902 '
                + '18.84975624084473 -1.9073486328125e-06 14.63009738922119 -1.9073486328125e-06 9.424877166748047 C -1.9073486328125e-06 4.219656944274902 4.219656944274902'
                + '-1.9073486328125e-06 9.424877166748047 -1.9073486328125e-06 Z'
        };
    };

    const disableButtonPaths = () => {
        return {
            circularSpace: 'M 12.77464866638184 25.0492992401123 C 9.495968818664551 25.0492992401123 6.413538455963135 23.77250862121582 4.095158576965332 21.45413780212402 C '
                    + '1.776788711547852 19.1357593536377 0.4999986588954926 16.05332946777344 0.4999986588954926 12.77464866638184 C 0.4999986588954926 9.495968818664551 1.776788711547852 '
                    + '6.413538455963135 4.095158576965332 4.095158576965332 C 6.413538455963135 1.776788711547852 9.495968818664551 0.4999986588954926 12.77464866638184 0.4999986588954926 '
                    + 'C 16.05332946777344 0.4999986588954926 19.1357593536377 1.776788711547852 21.45413780212402 4.095158576965332 C 23.77250862121582 6.413538455963135 25.0492992401123 '
                    + '9.495968818664551 25.0492992401123 12.77464866638184 C 25.0492992401123 16.05332946777344 23.77250862121582 19.1357593536377 21.45413780212402 21.45413780212402 C '
                    + '19.1357593536377 23.77250862121582 16.05332946777344 25.0492992401123 12.77464866638184 25.0492992401123 Z',
            outerCircle: 'M 12.77464866638184 0.9999980926513672 C 9.629528999328613 0.9999980926513672 6.672658920288086 2.22477912902832 4.448719024658203 4.448719024658203 C '
                    + '2.22477912902832 6.672658920288086 0.9999980926513672 9.629528999328613 0.9999980926513672 12.77464866638184 C 0.9999980926513672 15.91976833343506 2.22477912902832 '
                    + '18.87663841247559 4.448719024658203 21.10057830810547 C 6.672658920288086 23.32451820373535 9.629528999328613 24.5492992401123 12.77464866638184 24.5492992401123 C '
                    + '15.91976833343506 24.5492992401123 18.87663841247559 23.32451820373535 21.10057830810547 21.10057830810547 C 23.32451820373535 18.87663841247559 24.5492992401123 '
                    + '15.91976833343506 24.5492992401123 12.77464866638184 C 24.5492992401123 9.629528999328613 23.32451820373535 6.672658920288086 21.10057830810547 4.448719024658203 C '
                    + '18.87663841247559 2.22477912902832 15.91976833343506 0.9999980926513672 12.77464866638184 0.9999980926513672 M 12.77464866638184 -1.9073486328125e-06 C 19.82988929748535 '
                    + '-1.9073486328125e-06 25.5492992401123 5.71940803527832 25.5492992401123 12.77464866638184 C 25.5492992401123 19.82988929748535 19.82988929748535 25.5492992401123 '
                    + '12.77464866638184 25.5492992401123 C 5.71940803527832 25.5492992401123 -1.9073486328125e-06 19.82988929748535 -1.9073486328125e-06 12.77464866638184 C -1.9073486328125e-06 '
                    + '5.71940803527832 5.71940803527832 -1.9073486328125e-06 12.77464866638184 -1.9073486328125e-06 Z',
            innerCircleOutline: 'M 7.02605676651001 13.55211639404297 C 3.427576780319214 13.55211639404297 0.4999967813491821 10.62453651428223 0.4999967813491821 7.02605676651001 C '
                    + '0.4999967813491821 3.427576780319214 3.427576780319214 0.4999967813491821 7.02605676651001 0.4999967813491821 C 10.62453651428223 0.4999967813491821 '
                    + '13.55211639404297 3.427576780319214 13.55211639404297 7.02605676651001 C 13.55211639404297 10.62453651428223 10.62453651428223 13.55211639404297 7.02605676651001 '
                    + '13.55211639404297 Z',
            innerCircle: 'M 7.02605676651001 0.9999971389770508 C 3.703276634216309 0.9999971389770508 0.9999971389770508 3.703276634216309 0.9999971389770508 7.02605676651001 '
                    + 'C 0.9999971389770508 10.34883689880371 3.703276634216309 13.05211639404297 7.02605676651001 13.05211639404297 C 10.34883689880371 13.05211639404297 13.05211639404297 '
                    + '10.34883689880371 13.05211639404297 7.02605676651001 C 13.05211639404297 3.703276634216309 10.34883689880371 0.9999971389770508 7.02605676651001 0.9999971389770508 '
                    + 'M 7.02605676651001 -2.86102294921875e-06 C 10.90643692016602 -2.86102294921875e-06 14.05211639404297 3.145676612854004 14.05211639404297 7.02605676651001 C '
                    + '14.05211639404297 10.90643692016602 10.90643692016602 14.05211639404297 7.02605676651001 14.05211639404297 C 3.145676612854004 14.05211639404297 -2.86102294921875e-06 '
                    + '10.90643692016602 -2.86102294921875e-06 7.02605676651001 C -2.86102294921875e-06 3.145676612854004 3.145676612854004 -2.86102294921875e-06 7.02605676651001 '
                    + '-2.86102294921875e-06 Z'
        };
    };

    const enableButtonPaths = () => {
        return {
            innerCircleOutline: 'M 7.02605676651001 13.55211639404297 C 3.427576780319214 13.55211639404297 0.4999967813491821 10.62453651428223 0.4999967813491821 7.02605676651001 C '
                + '0.4999967813491821 3.427576780319214 3.427576780319214 0.4999967813491821 7.02605676651001 0.4999967813491821 C 10.62453651428223 0.4999967813491821 13.55211639404297 '
                + '3.427576780319214 13.55211639404297 7.02605676651001 C 13.55211639404297 10.62453651428223 10.62453651428223 13.55211639404297 7.02605676651001 13.55211639404297 Z',
            innerCircle: 'M 7.02605676651001 0.9999971389770508 C 3.703276634216309 0.9999971389770508 0.9999971389770508 3.703276634216309 0.9999971389770508 7.02605676651001 '
                + 'C 0.9999971389770508 10.34883689880371 3.703276634216309 13.05211639404297 7.02605676651001 13.05211639404297 C 10.34883689880371 13.05211639404297 13.05211639404297 '
                + '10.34883689880371 13.05211639404297 7.02605676651001 C 13.05211639404297 3.703276634216309 10.34883689880371 0.9999971389770508 7.02605676651001 0.9999971389770508 M '
                + '7.02605676651001 -2.86102294921875e-06 C 10.90643692016602 -2.86102294921875e-06 14.05211639404297 3.145676612854004 14.05211639404297 7.02605676651001 C 14.05211639404297 '
                + '10.90643692016602 10.90643692016602 14.05211639404297 7.02605676651001 14.05211639404297 C 3.145676612854004 14.05211639404297 -2.86102294921875e-06 10.90643692016602 '
                + '-2.86102294921875e-06 7.02605676651001 C -2.86102294921875e-06 3.145676612854004 3.145676612854004 -2.86102294921875e-06 7.02605676651001 -2.86102294921875e-06 Z'
        };
    };

    const transferPointButtonPaths = () => {
        return {
            innerCircle: 'M 7.02605676651001 0.9999971389770508 C 3.703276634216309 0.9999971389770508 0.9999971389770508 3.703276634216309 0.9999971389770508 7.02605676651001 C 0.9999971389770508 '
            + '10.34883689880371 3.703276634216309 13.05211639404297 7.02605676651001 13.05211639404297 C 10.34883689880371 13.05211639404297 13.05211639404297 10.34883689880371 13.05211639404297 '
            + '7.02605676651001 C 13.05211639404297 3.703276634216309 10.34883689880371 0.9999971389770508 7.02605676651001 0.9999971389770508 M 7.02605676651001 -2.86102294921875e-06 C '
            + '10.90643692016602 -2.86102294921875e-06 14.05211639404297 3.145676612854004 14.05211639404297 7.02605676651001 C 14.05211639404297 10.90643692016602 10.90643692016602 '
            + '14.05211639404297 7.02605676651001 14.05211639404297 C 3.145676612854004 14.05211639404297 -2.86102294921875e-06 10.90643692016602 -2.86102294921875e-06 7.02605676651001 C '
            + '-2.86102294921875e-06 3.145676612854004 3.145676612854004 -2.86102294921875e-06 7.02605676651001 -2.86102294921875e-06 Z'
        };
    };

    const settingButtonPaths = () => {
        return {
            outerCircleOutline: 'M 13 25.5 C 9.661129951477051 25.5 6.52209997177124 24.19976997375488 4.16117000579834 21.83883094787598 C 1.800230026245117 19.4778995513916 '
            + '0.5 16.33886909484863 0.5 13 C 0.5 9.661129951477051 1.800230026245117 6.52209997177124 4.16117000579834 4.16117000579834 C 6.52209997177124 1.800230026245117 '
            + '9.661129951477051 0.5 13 0.5 C 16.33886909484863 0.5 19.4778995513916 1.800230026245117 21.83883094787598 4.16117000579834 C 24.19976997375488 6.52209997177124 '
            + '25.5 9.661129951477051 25.5 13 C 25.5 16.33886909484863 24.19976997375488 19.4778995513916 21.83883094787598 21.83883094787598 C 19.4778995513916 24.19976997375488 '
            + '16.33886909484863 25.5 13 25.5 Z',
            outerCircle: 'M 13 1 C 9.794679641723633 1 6.781219482421875 2.248220443725586 4.514720916748047 4.514720916748047 C 2.248220443725586 6.781219482421875 1 '
            + '9.794679641723633 1 13 C 1 16.20532035827637 2.248220443725586 19.21878051757813 4.514720916748047 21.48527908325195 C 6.781219482421875 23.75177955627441 '
            + '9.794679641723633 25 13 25 C 16.20532035827637 25 19.21878051757813 23.75177955627441 21.48527908325195 21.48527908325195 C 23.75177955627441 19.21878051757813 '
            + '25 16.20532035827637 25 13 C 25 9.794679641723633 23.75177955627441 6.781219482421875 21.48527908325195 4.514720916748047 C 19.21878051757813 2.248220443725586 '
            + '16.20532035827637 1 13 1 M 13 0 C 20.1796989440918 0 26 5.82029914855957 26 13 C 26 20.1796989440918 20.1796989440918 26 13 26 C 5.82029914855957 26 0 '
            + '20.1796989440918 0 13 C 0 5.82029914855957 5.82029914855957 0 13 0 Z',
            iconToolRance: 'M42.346,48.751l.288-2.9,2.242-.893h1.26l1.389-1.439-3.1-3.075-1.2-.645-.4-.923.814-.7,1.022.7.417,1.081L48.2,42.8,50.055, '
            + '40.9l.169-.665v-.814l.475-.931.325-.319.356-.306.438-.163.506-.119h.506l.188.119-1.2, '
            + '1.173-.131.27.063.356.188.3.894.923.419.178h.325l.388-.178, '
            + '1.013-1.044.106.121v.437l-.106.561-.294.631-.375.4-.431.35-.55.175-.638.156-.475-.062-.394.063-1.356,1.272c.025,0-1.394,1.331-1.394,1.331l-1.622, '
            + '1.45-.125.806-.175.925-.4,1.4-1.869.55-.768.256Z',
            iconToolRanceOutline: 'M44.133,50.622a.175.175,0,0,1-.115-.042l-1.853-1.6a.175.175,0,0,1-.059-.15l.29-2.886a.175.175,0,0,1,.11-.143l2.395-.967a.136.136,0,0,1, '
            + '.058-.012l1.084-.051c.35-.362,2.622-2.654,3.834-3.9a.61.61,0,0,0,.136-.428,2.743,2.743,0,0,1,.874-2.4,2.4,2.4,0,0,1,2.192-.565.177.177,0,0,1, '
            + '.08.3l-.337.323c-.241.229-.469.448-.7.673a.6.6,0,0,0-.012.958c.316.339.561.589.815.823a.6.6,0,0,0,.923,0c.233-.224.451-.455.684-.7l.316-.334a.174.174,0,0,1,.287.054, '
            + '2.245,2.245,0,0,1-.711,2.4,2.717,2.717,0,0,1-2.22.657.572.572,0,0,0-.393.119c-1.3,1.276-3.846,3.61-4.239,3.968l-.065.832v.033l-.584,2.143a.175.175,0,0, '
            + '1-.119.122l-2.619.773A.175.175,0,0,1,44.133,50.622Zm-1.671-1.85,1.722,1.482,2.435-.713.537-2.035.065-.883a.175.175,0,0,1,.056-.115c.03-.026,2.883-2.634, '
            + '4.281-4.009a.9.9,0,0,1,.685-.215,2.353,2.353,0,0,0,1.953-.579,2.028,2.028,0,0,0,.7-1.725l-.1.1c-.234.246-.456.481-.7.71a.922.922,0,0, '
            + '1-1.4.012c-.26-.239-.524-.507-.836-.841a.94.94,0,0,1,.019-1.44c.226-.229.456-.449.7-.682l.082-.079a2.054,2.054,0,0,0-1.542.538,2.4,2.4,0,0,0-.76,2.1.946.946,0,0, '
            + '1-.234.718c-1.316,1.348-3.858,3.923-3.883,3.947a.175.175,0,0,1-.117.052l-1.122.052-2.273.907Zm2.15.6a.175.175,0,0,1-.122-.051l-1.142-1.107a.175.175,0,0, '
            + '1-.049-.159l.278-1.4a.175.175,0,0,1,.122-.133l1.614-.477a.175.175,0,0,1,.175.04l1.086,1.005a.175.175,0,0,1,.049.175l-.446,1.594a.175.175,0,0, '
            + '1-.122.122l-1.4.385a.222.222,0,0,1-.044.005Zm-.953-1.339,1,.97,1.2-.332.39-1.4-.934-.865-1.418.42Z',
            iconToolDriver: 'M84.218,81.56a.932.932,0,0,1-.664-.28c-.935-.923-1.871-1.871-2.769-2.787L79.76,77.459a.175.175,0,0,1,0-.246l1.923-1.9a.2.2,0,0,1,.126-.051.175.175,0,0,1, '
            + '.122.052l2.942,3,.269.271c.14.142.28.281.418.425l.024.026a1.5,1.5,0,0,1,.252.309c.4.71-.246,1.4-.855,1.923a1.184,1.184,0,0,1-.764.3Zm-4.082-4.222c.3.3.6.6.9.911.9.914, '
            + '1.834,1.862,2.766,2.783a.677.677,0,0,0,.956-.044c.958-.816.93-1.206.776-1.477a1.247,1.247,0,0, '
            + '0-.2-.238l-.026-.026c-.136-.142-.274-.281-.414-.421l-.269-.273-2.82-2.872Z',
            iconToolDriverOutline: 'M49.749,46.387a.175.175,0,0,1-.126-.052c-.6-.624-2.731-2.825-2.961-3.056l-.986-.524a.175.175,0,0,1-.061-.054l-.621-.9a.175.175,0,0,1, '
            + '.019-.222l.813-.827a.175.175,0,0,1,.226-.019l.965.687a.189.189,0,0,1,.052.059l.5.941c.8.766,2.851,2.739,3.031,2.877a.175.175,0,1, '
            + '1-.213.278c-.231-.175-2.8-2.65-3.08-2.93a.262.262,0,0,1-.033-.044l-.5-.928-.808-.572-.608.621.514.743.974.524a.147.147,0,0,1,.042.031s2.348,2.418,2.982, '
            + '3.077a.163.163,0,0,1-.126.285Z'
        };
    };

    return {
        settingButton: settingButtonPaths(),
        deleteButton: deleteButtonPaths(),
        disableButton: disableButtonPaths(),
        enableButton: enableButtonPaths(),
        transferPointButton: transferPointButtonPaths()
    };
}());

export { svgPaths };