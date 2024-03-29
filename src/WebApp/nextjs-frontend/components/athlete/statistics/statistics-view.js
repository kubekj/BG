//import style from "../dashboard/dashboard-main.module.css";
//import style from "./statistics-view-module.css" //czemu to nie działa? xd
import style from "./stat.module.css";
import React from "react";
import {
    ArcElement,
    BarElement,
    CategoryScale,
    Chart as ChartJS,
    Filler,
    Legend,
    LinearScale,
    LineElement,
    PointElement,
    Title,
    Tooltip,
} from "chart.js";
import {Bar, Doughnut, Line} from "react-chartjs-2";
import faker from "faker";

ChartJS.register(
    CategoryScale,
    LinearScale,
    LineElement,
    PointElement,
    BarElement,
    Filler,
    Title,
    ArcElement,
    Tooltip,
    Legend
);

const StatisticsView = ({weightBreakdown, doneTrainings, user}) => {
    const options = {
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
                    text: "Kilograms",
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
    const optionsL = {
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
                // min: 0,
                // max: 15000,
                title: {
                    display: true,
                    text: "Training load (kg lifted)",
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

    const labels = [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December",
    ];

    let apilabels = Object.keys(weightBreakdown);

    const data = {
        labels,
        datasets: [
            {
                label: "Body weight",
                data: apilabels.map((month) => weightBreakdown[month]),
                backgroundColor: "#C7D7FE",
            },
        ],
    };

    const options2 = {
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
    };

    const toDo = doneTrainings["item2"] - doneTrainings["item1"];
    const data2 = {
        labels: ["Done", "To do"],
        datasets: [
            {
                label: "Trainings",
                data: [doneTrainings["item1"], toDo],
                backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
                borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
                borderWidth: 1,
            },
        ],
    };

    const toEat = user.caloriesIntakeGoal - user.caloriesIntake;
    const data3 = {
        labels: ["Eaten", "To eat"],
        datasets: [
            {
                label: "Calories",
                data: [user.caloriesIntake, toEat],
                backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
                borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
                borderWidth: 1,
            },
        ],
    };

    const toBuild = user.weightGoal - user.weight;
    const data4 = {
        labels: ["Built", "To build"],
        datasets: [
            {
                label: "Weight(kg)",
                data: [user.weight, toBuild],
                backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
                borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
                borderWidth: 1,
            },
        ],
    };

    const dataL = {
        labels,
        datasets: [
            {
                fill: true,
                label: "Weight load",
                data: labels.map(() =>
                    doneTrainings["item1"] === 0
                        ? faker.datatype.number({min: 2000, max: 5000})
                        : null
                ),
                borderColor: "#8098F9",
                backgroundColor: "#8098F9",
            },
        ],
    };

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h2>Statistics</h2>
                <p>
                    Check out how are you doing compared to your previous achievements
                </p>
            </div>
            <div className={style.content}>
                <div className={style.barChart}>
                    <Bar options={options} data={data}/>
                </div>
                <div className={style.donutsSection}>
                    <div className={style.eachDonut}>
                        {doneTrainings["item2"] ? (
                            <React.Fragment>
                                <h5 className={style.statTitle}>
                                    Trainings done: {doneTrainings["item1"]}/
                                    {doneTrainings["item2"]}
                                </h5>
                                <Doughnut options={options2} data={data2}/>
                            </React.Fragment>
                        ) : (
                            <h5 className={style.statTitle}>No trainings goal set</h5>
                        )}
                    </div>
                    <div className={style.eachDonut}>
                        {user.caloriesIntakeGoal !== 0 ? (
                            <React.Fragment>
                                <h5 className={style.statTitle}>
                                    Calories intake: {user.caloriesIntake}/
                                    {user.caloriesIntakeGoal}
                                </h5>
                                <Doughnut options={options2} data={data3}/>
                            </React.Fragment>
                        ) : (
                            <h5 className={style.statTitle}>No calories intake goal set</h5>
                        )}
                    </div>
                    <div className={style.eachDonut}>
                        {user.weightGoal !== 0 ? (
                            <React.Fragment>
                                <h5 className={style.statTitle}>
                                    Body mass: {user.weight}/{user.weightGoal}
                                </h5>
                                <Doughnut options={options2} data={data4}/>
                            </React.Fragment>
                        ) : (
                            <h5 className={style.statTitle}>No body mass goal set</h5>
                        )}
                    </div>
                </div>
                <div className={style.bottomChart}>
                    <Line options={optionsL} data={dataL}/>
                </div>
            </div>
        </div>
    );
};

export default StatisticsView;
