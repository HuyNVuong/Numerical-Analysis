function newtonsEstimation = NewtonsDividedDifferences(x, n, xs, ys, debug)
    if ~exist('debug', 'var')
        debug = false;
    end
    fs = zeros(n, n);
    for i = 1:n
        fs(i,1) = ys(i);
    end
    for j = 2:n
        for i = j:n
            fs(i,j) = (fs(i,j - 1) - fs(i - 1,j - 1)) / (xs(i) - xs(i - j + 1));
        end
    end
    
    if debug
        disp(fs);
    end
    
    newtonsEstimation = 0;
    for i = 1:n
        xPolynomial = 1;
        for j = 1:(i - 1)
            xPolynomial = xPolynomial * (x - xs(j));
        end
        newtonsEstimation = newtonsEstimation + xPolynomial * fs(i,i);
    end       
end