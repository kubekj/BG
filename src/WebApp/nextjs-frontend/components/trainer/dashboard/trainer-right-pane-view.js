import style from "./trainer-right-pane-view.module.css";
import React from "react";
import {
    CategoryScale,
    Chart as ChartJS,
    Legend,
    LinearScale,
    LineElement,
    PointElement,
    Title,
    Tooltip,
} from "chart.js";
import {Line} from "react-chartjs-2";
import faker from "faker";
import Image from "next/image";

const sales = [419.99, 49.99];

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
);

export const options = {
    responsive: true,
    plugins: {
        legend: {
            display: false,
            position: "bottom",
        },
        title: {
            display: false,
            text: "Chart.js Bar Chart",
        },
    },
    scales: {
        y: {
            title: {
                display: true,
                text: "$",
            },
        },
        x: {
            title: {
                display: true,
                text: "Month",
            },
            grid: {
                display: false,
            },
        },
    },
};

const labels = ["January", "February", "March", "April", "May", "June"];
const actualLabels = ["January", "February"];

export const data = {
    labels,
    datasets: [
        {
            label: "Sales",
            data: actualLabels.map(() =>
                faker.datatype.number({min: 0, max: 499.99})
            ),
            borderColor: "#C7D7FE",
            backgroundColor: "#C7D7FE",
        },
    ],
};

const TrainerRightPaneView = () => {
    return (
        <div className={style.container}>
            <div className={style.header}>
                <h4>Earnings overtime</h4>
                <p style={{marginBottom: "2rem"}}>Compare earnings overtime</p>
            </div>
            <Line options={options} data={data}/>
            <div className={style.overview}>
                <h5 style={{marginBottom: "1rem"}}>Activity</h5>
                <div style={{borderTop: "1px solid #D0D5DD", marginBottom: "1rem"}}/>
                <div className={style.userInfo}>
                    <Image
                        className={style.avatar}
                        src='/avatar-w.avif'
                        alt='dadas'
                        width={30}
                        height={30}
                    />
                    <div>
                        <h5>John Doe</h5>
                        <p>john.doe@gmail.com</p>
                    </div>
                </div>
                <div className={style.userInfo}>
                    <Image
                        className={style.avatar}
                        src='/avatar-sample.jpg'
                        alt='dadas'
                        width={30}
                        height={30}
                    />
                    <div>
                        <h5>Tadeusz Soplica</h5>
                        <p>tadeusz.soplica@gmail.com</p>
                    </div>
                </div>
                {/* <div className={style.userInfo}>
          <Image
            className={style.avatar}
            src='/avatar.webp'
            alt='dadas'
            width={30}
            height={30}
          />
          <div>
            <h5>Jan Brzechwa</h5>
            <p>jan.brzechwa@gmail.com</p>
          </div>
        </div>
        <div className={style.userInfo}>
          <Image
            className={style.avatar}
            src='/jaca.avif'
            alt='dadas'
            width={30}
            height={30}
          />
          <div>
            <h5>Julian Tuwim</h5>
            <p>julian.tuwim@gmail.com</p>
          </div>
        </div>
        <div className={style.userInfo}>
          <Image
            className={style.avatar}
            src='/william.avif'
            alt='dadas'
            width={30}
            height={30}
          />
          <div>
            <h5>William Shakespeare</h5>
            <p>william.sheakspear@gmail.com</p>
          </div>
        </div>
        <div className={style.userInfo}>
          <Image
            className={style.avatar}
            src='/avatar-w.avif'
            alt='dadas'
            width={30}
            height={30}
          />
          <div>
            <h5>Albert Camus</h5>
            <p>albert.camus@gmail.com</p>
          </div>
        </div>
        <div className={style.userInfo}>
          <Image
            className={style.avatar}
            src='/einstein.avif'
            alt='dadas'
            width={30}
            height={30}
          />
          <div>
            <h5>Albert Einstein</h5>
            <p>albert.einstein@gmail.com</p>
          </div>
        </div> */}
            </div>
        </div>
    );
};

export default TrainerRightPaneView;
