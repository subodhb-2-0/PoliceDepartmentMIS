import PropTypes from 'prop-types';
import { forwardRef } from 'react';
import { useTheme } from '@mui/material/styles';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardHeader from '@mui/material/CardHeader';
import Divider from '@mui/material/Divider';
import Typography from '@mui/material/Typography';

// Header styling
const headerSX = {
  p: 2.5,
  '& .MuiCardHeader-action': { m: '0px auto', alignSelf: 'center' }
};

const MainCard = (
  {
    border = false,
    boxShadow = true,
    children,
    content = true,
    contentSX = {},
    darkTitle,
    elevation = 0,
    secondary,
    shadow,
    sx = {},
    title,
    ...others
  },
  ref
) => {
  const theme = useTheme();

  // Use dark shadow mode based on the theme
  const cardShadow = theme.palette.mode === 'dark' ? shadow || theme.customShadows.z1 : shadow;

  return (
    <Card
      elevation={elevation}
      ref={ref}
      {...others}
      sx={{
        border: border ? '1px solid' : 'none',
        borderRadius: 2,
        borderColor: theme.palette.mode === 'dark' ? theme.palette.divider : theme.palette.grey.A800,
        boxShadow: boxShadow && (!border || theme.palette.mode === 'dark') ? cardShadow : 'inherit',
        ':hover': {
          boxShadow: boxShadow ? cardShadow : 'inherit'
        },
        '& pre': {
          m: 0,
          p: '16px !important',
          fontFamily: theme.typography.fontFamily,
          fontSize: '0.75rem'
        },
          // Adjust the width (for example, 100% to make it full-width of its container)
        width: '80dvw',
        ...sx
      }}
    >
      {/* Card Header with optional title and secondary action */}
      {title && (
        <CardHeader
          sx={headerSX}
          titleTypographyProps={{ variant: darkTitle ? 'h3' : 'subtitle1' }}
          title={darkTitle ? <Typography variant="h3">{title}</Typography> : title}
          action={secondary}
        />
      )}

      {/* Card Content - Render children if content is true */}
      {content && <CardContent sx={contentSX}>{children}</CardContent>}
      {!content && children}
    </Card>
  );
};

export default forwardRef(MainCard);

// Define PropTypes for better validation and development experience
MainCard.propTypes = {
  border: PropTypes.bool,
  boxShadow: PropTypes.bool,
  children: PropTypes.node,
  content: PropTypes.bool,
  contentSX: PropTypes.object,
  darkTitle: PropTypes.bool,
  elevation: PropTypes.number,
  secondary: PropTypes.any,
  shadow: PropTypes.string,
  sx: PropTypes.object,
  title: PropTypes.oneOfType([PropTypes.string, PropTypes.node]),
  others: PropTypes.any
};
