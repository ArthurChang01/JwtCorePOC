import * as constant from '../constants';

export interface Action {
    type: string;
}

export interface Counter extends Action {
    amount: number;
}

export function increase(n): Counter {
    return {
        type: constant.INCREASE,
        amount: n
    };
}

export function decrease(n): Counter {
    return {
        type: constant.DECREASE,
        amount: n
    };
}
